namespace Lab2.Models
{
	public class LogEntry
	{
		public string Type { get; }

		public string Date { get; }

		public string Time { get; }

		public string AddressIn { get; }

		public string AddressOut { get; }

		public string Protocol { get; }

		public LogEntry(string[] parts)
		{
			Type = parts[0];
			Date = parts[1];
			Time = parts[2];
			AddressIn = parts[3];
			AddressOut = parts[4];
			Protocol = parts[5];
		}
	}
}