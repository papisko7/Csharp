using CookieCookBook.FileManagement;
using CookieCookBook.Logic;
using CookieCookBook.Logic.Repositories;

namespace CookieCookBook
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const string filePath = "recipes.json";
			var app = new Application(new RecipesRepository(new StringsTextualRepository()), new RecipesConsoleUserInteraction(new IngredientsRegister()));

			app.Run(filePath);
		}
	}
}