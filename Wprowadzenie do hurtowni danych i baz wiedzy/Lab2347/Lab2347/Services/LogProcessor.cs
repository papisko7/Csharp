using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Lab2.Interfaces;
using Lab2.Models;

namespace Lab2.Services
{
	public sealed class LogProcessor : ILogProcessor
	{
		private readonly string _connectionString = @"Data Source=192.168.137.216\PRVSQL16; Initial Catalog=HurtowniaLabKK; User ID=sa; Password=sql;";
		private readonly HashSet<string> _processedFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private SqlConnection _connection;

		private void OpenDbConnection()
		{
			if (_connection == null)
				_connection = new SqlConnection(_connectionString);

			if (_connection.State != ConnectionState.Open)
				_connection.Open();
		}

		private void CloseDbConnection()
		{
			if (_connection != null && _connection.State == ConnectionState.Open)
				_connection.Close();
		}

		public ParsedLogData ProcessFile(string filePath)
		{
			var data = new ParsedLogData();

			OpenDbConnection();
			ProcessSingleFile(filePath, data);
			data.ProcessedFiles.Add(Path.GetFileName(filePath));
			CloseDbConnection();

			return data;
		}

		public ParsedLogData ProcessDirectoryForBw(string directoryPath,
			BackgroundWorker worker,
			ManualResetEvent pauseHandle)
		{
			OpenDbConnection();
			var data = new ParsedLogData();
			string[] allFiles = Directory.GetFiles(directoryPath, "*.txt");
			string[] files = allFiles.Where(f => !_processedFiles.Contains(Path.GetFileName(f))).ToArray();

			if (files.Length == 0)
			{
				CloseDbConnection();
				return data;
			}

			const int batchSize = 20;
			var batchFilesCount = 0;
			var batchLinesCount = 0;
			var batchEntriesCount = 0;
			var lastFileName = string.Empty;

			for (var i = 0; i < allFiles.Length; i++)
			{
				pauseHandle.WaitOne();
				if (worker.CancellationPending) break;

				string filePath = allFiles[i];
				string fileName = Path.GetFileName(filePath);

				try
				{
					var linesBefore = data.AllLines.Count;
					var entriesBefore = data.ValidEntries.Count;

					ProcessSingleFile(filePath, data);

					data.ProcessedFiles.Add(fileName);
					_processedFiles.Add(fileName);

					batchFilesCount++;
					lastFileName = fileName;

					batchLinesCount += (data.AllLines.Count - linesBefore);
					batchEntriesCount += (data.ValidEntries.Count - entriesBefore);
				}
				catch
				{
					// Fault tolerance: skip unreadable files
				}

				if (batchFilesCount < batchSize && i != allFiles.Length - 1)
				{
					continue;
				}

				int progress = (int)((i + 1) / (double)allFiles.Length * 100);
				var progressUpdate = new FileProcessedData
				{
					FileName = lastFileName,
					FilesCount = batchFilesCount,
					NewLinesCount = batchLinesCount,
					NewEntriesCount = batchEntriesCount
				};

				worker.ReportProgress(progress,
					progressUpdate);

				batchFilesCount = 0;
				batchLinesCount = 0;
				batchEntriesCount = 0;

				Thread.Sleep(1);
			}
			CloseDbConnection();
			return data;
		}

		private static string ReadElement(ref string line)
		{
			var index = line.IndexOf(',');
			if (index == -1)
			{
				string last = line;
				line = string.Empty;
				return last;
			}

			var element = line.Substring(0,
				index);
			line = line.Substring(index + 1);

			return element;
		}

		private void ProcessSingleFile(string filePath,
			ParsedLogData data)
		{
			const string sql = "INSERT INTO ZoneAlarmLog (Event, Date, Time, Source, Destination, Transport) " +
							   "VALUES (@Event, @Date, @Time, @Source, @Destination, @Transport)";

			using (var transaction = _connection.BeginTransaction())
			using (var command = new SqlCommand(sql, _connection, transaction))
			{
				command.Parameters.Add("@Event", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@Date", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@Time", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@Source", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@Destination", SqlDbType.NVarChar, 200);
				command.Parameters.Add("@Transport", SqlDbType.NVarChar, 200);

				using (var sr = new StreamReader(filePath))
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						data.AllLines.Add(line);

						var entry = TryParseLine(line);
						if (entry == null) continue;

						data.ValidEntries.Add(entry);
						data.ColTypes.Add(entry.Type);
						data.ColDates.Add(entry.Date);
						data.ColTimes.Add(entry.Time);
						data.ColAddressIn.Add(entry.AddressIn);
						data.ColAddressOut.Add(entry.AddressOut);
						data.ColProtocol.Add(entry.Protocol);

						try
						{
							command.Parameters["@Event"].Value = Truncate(entry.Type, 200);
							command.Parameters["@Date"].Value = Truncate(entry.Date, 200);
							command.Parameters["@Time"].Value = Truncate(entry.Time.Split('+')[0].Trim(), 200);
							command.Parameters["@Source"].Value = Truncate(entry.AddressIn, 200);
							command.Parameters["@Destination"].Value = Truncate(entry.AddressOut, 200);
							command.Parameters["@Transport"].Value = Truncate(entry.Protocol, 200);
							command.ExecuteNonQuery();
						}
						catch
						{
							// Fault tolerance: silently ignore individual insert errors
						}

						continue;

						string Truncate(string value, int max) =>
							value != null && value.Length > max ? value.Substring(0, max) : value;
					}
				}

				transaction.Commit();
			}
		}

		public int ProcessDirectorySync(string directoryPath, ParsedLogData data)
		{
			OpenDbConnection();
			string[] files = Directory.GetFiles(directoryPath, "*.txt")
				.Where(f => !_processedFiles.Contains(Path.GetFileName(f)))
				.ToArray();

			var newFilesCount = 0;
			foreach (string filePath in files)
			{
				string fileName = Path.GetFileName(filePath);
				try
				{
					ProcessSingleFile(filePath, data);
					data.ProcessedFiles.Add(fileName);
					_processedFiles.Add(fileName);
					newFilesCount++;
				}
				catch
				{
					// Fault tolerance: skip unreadable files
				}
			}

			CloseDbConnection();
			return newFilesCount;
		}

		public void ExecuteWarehouseScript(string scriptPath)
		{
			string fullSql = File.ReadAllText(scriptPath, Encoding.UTF8);
			string[] batches = Regex.Split(fullSql, @"^\s*GO\s*$",
				RegexOptions.Multiline | RegexOptions.IgnoreCase);

			OpenDbConnection();
			try
			{
				foreach (string batch in batches)
				{
					string trimmed = batch.Trim();
					if (string.IsNullOrEmpty(trimmed)) continue;

					using (var cmd = new SqlCommand(trimmed, _connection))
					{
						cmd.CommandTimeout = 120;
						cmd.ExecuteNonQuery();
					}
				}
			}
			finally
			{
				CloseDbConnection();
			}
		}

		private static LogEntry TryParseLine(string line)
		{
			if (string.IsNullOrWhiteSpace(line)) return null;

			var commaCount = line.Count(c => c == ',');

			if (commaCount != 5)
			{
				return null;
			}

			var tempLine = line;
			var parts = new string[6];
			for (var i = 0; i < 6; i++)
			{
				parts[i] = ReadElement(ref tempLine);
			}

			return parts[0].ToLower() == "type" ?
				null :
				new LogEntry(parts);
		}
	}
}