using CookieCookBook.FileAccess.Enum;

namespace CookieCookBook.FileAccess
{
	public static class FileFormatExtensions
	{
		public static string AsFileExtension(this FileFormat fileFormat) => fileFormat == FileFormat.Json ? ".json" : ".txt";
	}
}