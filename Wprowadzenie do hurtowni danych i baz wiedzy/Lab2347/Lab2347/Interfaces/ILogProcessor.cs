using System.ComponentModel;
using System.Threading;
using Lab2.Models;

namespace Lab2.Interfaces
{
	public interface ILogProcessor
	{
		ParsedLogData ProcessFile(string filePath);

		ParsedLogData ProcessDirectoryForBw(string directoryPath,
			BackgroundWorker worker,
			ManualResetEvent pauseHandle);

		int ProcessDirectorySync(string directoryPath, ParsedLogData data);

		void ExecuteWarehouseScript(string scriptPath);
	}
}