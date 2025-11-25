using CookieCookBook.DataAccess.Interface;

namespace CookieCookBook.DataAccess.Abstract
{
	public abstract class StringsRepository : IStringsRepository
	{
		public List<string> Read(string filePath)
		{
			if (File.Exists(filePath))
			{
				var fileContent = File.ReadAllText(filePath);
				return TextToStrings(fileContent);

			}

			return new List<string>();
		}

		public void Write(string filePath, List<string> allLines)
		{
			File.WriteAllText(filePath, StringsToText(allLines));
		}

		protected abstract List<string> TextToStrings(string fileContent);

		protected abstract string StringsToText(List<string> allLines);
	}
}