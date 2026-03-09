namespace StarWarsPlanetsData.Extensions
{
	public static class StringExtensions
	{
		public static int? ToIntOrNull(this string? input)
		{
			return int.TryParse(input, out var resultParsed)
				? resultParsed
				: null;
		}

		public static long? ToLongOrNull(this string? input)
		{
			return long.TryParse(input, out var resultParsed)
				? resultParsed
				: null;
		}
	}
}
