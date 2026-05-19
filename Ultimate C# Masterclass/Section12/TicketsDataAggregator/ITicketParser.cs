using System.Globalization;

namespace TicketsDataAggregator;

public interface ITicketParser
{
	IEnumerable<TicketData> ExtractTickets(string text, CultureInfo cultureInfo);
}