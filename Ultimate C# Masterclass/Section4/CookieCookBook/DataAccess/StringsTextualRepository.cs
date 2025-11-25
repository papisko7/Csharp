using CookieCookBook.DataAccess.Abstract;

namespace CookieCookBook.DataAccess
{
	public class StringsTextualRepository : StringsRepository
	{
		private static readonly string SEPARATOR = Environment.NewLine;

		protected override string StringsToText(List<string> allLines)
		{
			return string.Join(SEPARATOR, allLines);
		}

		protected override List<string> TextToStrings(string fileContent)
		{
			return fileContent.Split(SEPARATOR).ToList();
		}
	}
}