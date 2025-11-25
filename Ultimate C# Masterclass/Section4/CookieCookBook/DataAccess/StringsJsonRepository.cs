using CookieCookBook.DataAccess.Abstract;
using System.Text.Json;

namespace CookieCookBook.DataAccess
{
	public class StringsJsonRepository : StringsRepository
	{
		protected override string StringsToText(List<string> allLines)
		{
			return JsonSerializer.Serialize(allLines);
		}

		protected override List<string> TextToStrings(string fileContent)
		{
			return JsonSerializer.Deserialize<List<string>>(fileContent);
		}
	}
}