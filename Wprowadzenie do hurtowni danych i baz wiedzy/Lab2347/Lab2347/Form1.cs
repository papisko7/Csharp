using System;
using System.IO;
using System.Windows.Forms;
using Lab2.Interfaces;
using Lab2.Models;

namespace Lab2
{
	public partial class Form1 : Form
	{
		private const string DEFAULT_FILE_PATH = @"C:\Users\kacperkowalski\Downloads\db";
		private const string WAREHOUSE_SCRIPT = @"SQL_Wholesaler_Query.sql";

		private readonly ILogProcessor _logProcessor;
		private readonly IDialogService _dialogService;
		private readonly ListBox[] _listBoxes;

		private int _liveLinesCount;
		private int _liveFilesCount;
		private ParsedLogData _orchestratorData = new ParsedLogData();

		public Form1(ILogProcessor logProcessor,
			IDialogService dialogService)
		{
			InitializeComponent();

			_logProcessor = logProcessor ??
							throw new ArgumentNullException(nameof(logProcessor));
			_dialogService = dialogService ??
							 throw new ArgumentNullException(nameof(dialogService));

			_listBoxes = new[]
			{
				ListBox1,
				ListBox2,
				ListBox3,
				ListBox4,
				ListBox5,
				ListBox6,
				ListBox7
			};

			TextFilePath.Text = DEFAULT_FILE_PATH;
			LblLoadedLines.Text = string.Empty;
		}

		private void BtnImport_Click(object sender,
			EventArgs e)
		{
			ClearListBoxes();
			var filePath = TextFilePath.Text;

			if (File.Exists(filePath))
			{
				ParsedLogData result = _logProcessor.ProcessFile(filePath);
				PopulateListBoxes(result);

				LblLoadedLines.Text = $@"Processed files: 1 | Total lines read: {result.AllLines.Count}" +
									  $@"| Valid entries: {result.ValidEntries.Count}";
			}
			else
			{
				_dialogService.ShowError(@"Choose a correct text file.",
					@"File not found");
			}
		}

		private void BtnImportFolder_Click(object sender,
			EventArgs e)
		{
			var folderPath = TextFilePath.Text;

			if (!Directory.Exists(folderPath))
			{
				_dialogService.ShowError(@"Choose a correct folder.",
					@"Error");
				return;
			}

			ClearListBoxes();

			BtnImportFolder.Enabled = false;
			_liveLinesCount = 0;
			_liveFilesCount = 0;
			LblLoadedLines.Text = string.Empty;

			var progressForm = new ProgressForm(folderPath,
				_logProcessor);

			progressForm.FileProcessed += ProgressForm_FileProcessed;
			progressForm.FormClosed += ProgressForm_FormClosed;
			progressForm.ShowDialog(this);
		}

		private void ProgressForm_FileProcessed(FileProcessedData fileData)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<FileProcessedData>(ProgressForm_FileProcessed), fileData);
				return;
			}

			_liveLinesCount += fileData.NewLinesCount;
			_liveFilesCount += fileData.FilesCount;

			LblLoadedLines.Text = $@"Status: Reading files... Files: {_liveFilesCount}"
								  + $@"| Lines: {_liveLinesCount}";
		}

		private void ProgressForm_FormClosed(object sender,
			FormClosedEventArgs e)
		{
			var progressForm = (ProgressForm)sender;

			switch (progressForm.IsCancelled)
			{
				case false when progressForm.Result != null:
					PopulateListBoxes(progressForm.Result);

					LblLoadedLines.Text = $@"Processed files: {progressForm.Result.ProcessedFiles.Count} | " +
										  $@"Total lines read: {progressForm.Result.AllLines.Count} | " +
										  $@"Valid entries: {progressForm.Result.ValidEntries.Count}";
					break;
				case true:
					LblLoadedLines.Text = @"Import cancelled by user.";
					break;
			}

			progressForm.Dispose();
			BtnImportFolder.Enabled = true;
		}

		private void PopulateListBoxes(ParsedLogData data)
		{
			if (data == null) return;

			ClearListBoxes();

			ListBox1.DataSource = data.AllLines;
			ListBox2.DataSource = data.ColTypes;
			ListBox3.DataSource = data.ColDates;
			ListBox4.DataSource = data.ColTimes;
			ListBox5.DataSource = data.ColAddressIn;
			ListBox6.DataSource = data.ColAddressOut;
			ListBox7.DataSource = data.ColProtocol;
		}

		private void ClearListBoxes()
		{
			foreach (var listBox in _listBoxes)
			{
				listBox.DataSource = null;
				listBox.Items.Clear();
			}
		}

		private void BtnBrowse_Click(object sender,
			EventArgs e)
		{
			var selectedPath = _dialogService.ShowFileDialog(@"Choose a file to read",
				@"Text files (*.txt)|*.txt|All files (*.*)|*.*");

			if (selectedPath != null)
			{
				TextFilePath.Text = selectedPath;
			}
		}

		private void BtnBrowseFolder_Click(object sender,
			EventArgs e)
		{
			var selectedPath = _dialogService.ShowFolderDialog();
			if (selectedPath != null)
			{
				TextFilePath.Text = selectedPath;
			}
		}

		private void BtnAbout_Click(object sender, EventArgs e)
		{
			_dialogService.ShowInfo(
				@"Authors: Kacper Kowalski" +
				Environment.NewLine + Environment.NewLine +
				@"Program: Lab2347",
				@"About");
		}

		private void BtnToggleUpdate_Click(object sender, EventArgs e)
		{
			if (UpdateTimer.Enabled)
			{
				UpdateTimer.Stop();
				BtnToggleUpdate.Text = "Enable updates";
				LblOrchestratorStatus.Text = "Orchestrator: OFF";
			}
			else
			{
				UpdateTimer.Interval = (int)NumUpdateInterval.Value * 1000;
				UpdateTimer.Start();
				BtnToggleUpdate.Text = "Disable updates";
				LblOrchestratorStatus.Text = "Orchestrator: ON";
			}
		}

		private void UpdateTimer_Tick(object sender, EventArgs e)
		{
			UpdateTimer.Stop();

			var folderPath = TextAutoFolderPath.Text;
			if (!Directory.Exists(folderPath))
			{
				LblOrchestratorStatus.Text = "Orchestrator: ERROR - folder does not exist";
				UpdateTimer.Start();
				return;
			}

			LblOrchestratorStatus.Text = "Orchestrator: scanning...";
			int newFiles;
			try
			{
				newFiles = _logProcessor.ProcessDirectorySync(folderPath, _orchestratorData);
			}
			catch (Exception ex)
			{
				LblOrchestratorStatus.Text = $"Orchestrator: ETL error - {ex.Message}";
				UpdateTimer.Start();
				return;
			}

			if (newFiles > 0)
			{
				LblOrchestratorStatus.Text = "Orchestrator: rebuilding warehouse...";
				try
				{
					string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, WAREHOUSE_SCRIPT);
					_logProcessor.ExecuteWarehouseScript(scriptPath);
				}
				catch (Exception ex)
				{
					LblOrchestratorStatus.Text = $"Orchestrator: SQL error - {ex.Message}";
					UpdateTimer.Start();
					return;
				}

				RefreshUiFromOrchestratorData();

				MessageBox.Show(
					$"Warehouse rebuilt successfully.\n\nNew files processed: {newFiles}\n" +
					$"Total files: {_orchestratorData.ProcessedFiles.Count}\n" +
					$"Total valid entries: {_orchestratorData.ValidEntries.Count}",
					"Orchestrator - Success",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}

			LblOrchestratorStatus.Text = $"Orchestrator: ON | last tick: {DateTime.Now:HH:mm:ss}" +
										 $" | total files: {_orchestratorData.ProcessedFiles.Count}";
			UpdateTimer.Start();
		}

		private void RefreshUiFromOrchestratorData()
		{
			PopulateListBoxes(_orchestratorData);
			LblLoadedLines.Text = $"Processed files: {_orchestratorData.ProcessedFiles.Count} | " +
								  $"Total lines read: {_orchestratorData.AllLines.Count} | " +
								  $"Valid entries: {_orchestratorData.ValidEntries.Count}";
		}
	}
}