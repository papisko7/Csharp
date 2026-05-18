using System.Globalization;

namespace TicketsDataAggregator
{
	public static class CultureManager
	{
		private static readonly Dictionary<string, string> DomainCultures = new()
		{
			{ ".com" , "en-US" },
			{ ".fr", "fr-Fr" },
			{ ".ja", "ja-JP" }
		};

		public static CultureInfo GetCulture(string text)
		{
			var matchedDomain = DomainCultures.FirstOrDefault(d => text.Contains(d.Key));

			return matchedDomain.Key != null
				? new CultureInfo(matchedDomain.Value)
				: CultureInfo.InvariantCulture;
		}
	}
}