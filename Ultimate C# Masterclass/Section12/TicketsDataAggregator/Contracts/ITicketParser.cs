using System.Globalization;
using TicketsDataAggregator.Models;

namespace TicketsDataAggregator.Contracts;

public interface ITicketParser
{
	IEnumerable<TicketData> ExtractTickets(string text, CultureInfo cultureInfo);
}