namespace GameDataParser.Logging
{
	public class Logger
	{
		private string _logFilePath;

		public Logger(string logFilePath)
		{
			_logFilePath = logFilePath;
		}

		public void Log(Exception ex)
		{
			var entry = $@"[{DateTime.Now}]
				Exception  message: {ex.Message}
				Stack trace: {ex.StackTrace}";
			File.AppendAllText(_logFilePath, entry);
		}
	}
}