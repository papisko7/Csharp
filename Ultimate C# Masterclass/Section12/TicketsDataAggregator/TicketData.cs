using System.Globalization;

namespace TicketsDataAggregator
{
	public class TicketData
	{
		public string MovieName { get; set; }

		public DateTime Date { get; set; }

		public DateTime Time { get; set; }

		public string ToString()
		{
			var dateStr = Date.ToString("d", CultureInfo.InvariantCulture);
			var timeStr = Time.ToString("t", CultureInfo.InvariantCulture);

			return $"{MovieName,-20} | {dateStr} | {timeStr}";
			;
		}
	}
}