using System.Globalization;

namespace TicketsDataAggregator
{
	public class TicketData(string movieName,
		DateTime date, DateTime time)
	{
		public string MovieName { get; set; } = movieName;

		public DateTime Date { get; set; } = date;

		public DateTime Time { get; set; } = time;

		public override string ToString()
		{
			var dateStr = Date.ToString("d", CultureInfo.InvariantCulture);
			var timeStr = Time.ToString("t", CultureInfo.InvariantCulture);

			return $"{MovieName,-20} | {dateStr} | {timeStr}";
		}
	}
}