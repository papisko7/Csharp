using System.Globalization;
using System.Text.RegularExpressions;

namespace TicketsDataAggregator
{
	public static class TicketParser
	{
		private const string TICKET_PATTERN = @"Title:\s*(.*?)\s*Date:\s*(.*?)\s*Time:\s*(.*?)(?=\s*Title:|\s*Visit us:|$)";

		public static IEnumerable<TicketData> ExtractTickets(string text,
			CultureInfo cultureInfo)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				yield break;
			}

			var matches = Regex.Matches(text, TICKET_PATTERN, RegexOptions.Singleline);

			foreach (Match match in matches)
			{
				var movieNameStr = match.Groups[1].Value.Replace("\n", "").Replace("\r", "").Trim();
				var dateStr = match.Groups[2].Value.Trim();
				var timeStr = match.Groups[3].Value.Trim();

				if (DateTime.TryParse(dateStr, cultureInfo, DateTimeStyles.None, out var parsedDate) &&
					DateTime.TryParse(timeStr, cultureInfo, DateTimeStyles.None, out var parsedTime))
				{
					yield return new TicketData(movieNameStr,
						parsedDate,
						parsedTime);
				}
			}
		}
	}
}