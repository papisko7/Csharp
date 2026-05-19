using System.Globalization;

namespace TicketsDataAggregator;

public interface ICultureManager
{
	CultureInfo GetCulture(string text);
}