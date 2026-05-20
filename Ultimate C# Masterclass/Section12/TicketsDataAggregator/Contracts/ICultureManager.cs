using System.Globalization;

namespace TicketsDataAggregator.Contracts;

public interface ICultureManager
{
	CultureInfo GetCulture(string text);
}