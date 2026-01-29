using CookieCookBook.App;
using CookieCookBook.DataAccess;
using CookieCookBook.DataAccess.Interface;
using CookieCookBook.FileAccess;
using CookieCookBook.FileAccess.Enum;
using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients;

namespace CookieCookBook
{
	public class Program
	{
		private const FileFormat FORMAT = FileFormat.Txt;
		private const string FILE_NAME = "recipes";

		private static IStringsRepository _stringsRepository;
		private static FileMetadata _fileMetadata;

		public static void Main(string[] args)
		{
			_stringsRepository = FORMAT == FileFormat.Json
			   ? new StringsJsonRepository()
			   : new StringsTextualRepository();
			_fileMetadata = new FileMetadata(FILE_NAME, FORMAT);

			var filePath = FORMAT == FileFormat.Json
				? $"{FILE_NAME}.json"
				: $"{FILE_NAME}.txt";
			var ingredientRegister = new IngredientsRegister();
			var app = new CookiesRecipesApp(new RecipesRepository(_stringsRepository, ingredientRegister),
				new RecipesConsoleUserInteraction(ingredientRegister));

			app.Run(_fileMetadata.ToPath());
		}
	}
}