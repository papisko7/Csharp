using CookieCookBook.Logic;

namespace CookieCookBook
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const string filePath = "recipes.json";
			var app = new Application(new RecipesRepository(), new RecipesConsoleUserInteraction(new IngredientsRegister()));

			app.Run(filePath);
		}
	}
}