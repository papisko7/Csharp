using System.Collections.Generic;

namespace Lab2.Models
{
	public class ParsedLogData
	{
		public List<string> AllLines { get; } = new List<string>();

		public List<LogEntry> ValidEntries { get; } = new List<LogEntry>();

		public List<string> ProcessedFiles { get; } = new List<string>();

		public List<string> ColTypes { get; } = new List<string>();

		public List<string> ColDates { get; } = new List<string>();

		public List<string> ColTimes { get; } = new List<string>();

		public List<string> ColAddressIn { get; } = new List<string>();

		public List<string> ColAddressOut { get; } = new List<string>();

		public List<string> ColProtocol { get; } = new List<string>();
	}
}