using System.Globalization;

namespace TicketsDataAggregator
{
	public static class CultureManager
	{
		public static CultureInfo getCulture(string text) => text.Contains(".com") ? new CultureInfo("en-US") :
			text.Contains(".fr") ? new CultureInfo("fr-Fr") :
			text.Contains(".ja") ? new CultureInfo("ja-JP") :
			CultureInfo.InvariantCulture;
	}
}