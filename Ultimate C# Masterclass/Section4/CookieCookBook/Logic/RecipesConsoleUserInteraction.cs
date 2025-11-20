using CookieCookBook.Recipes;
using CookieCookBook.Templates;

namespace CookieCookBook.Logic
{
	public class RecipesConsoleUserInteraction : IRecipesUserInteraction
	{
		private readonly IngredientsRegister _ingredientsRegister;


		public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
		{
			_ingredientsRegister = ingredientsRegister;
		}

		public void Exit()
		{
			Console.WriteLine("Press any key to close.");
			Console.ReadKey();
		}

		public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
		{
			var counter = 1;

			if (allRecipes.Count() > 0)
			{
				Console.WriteLine("Existing recipes are:\n");

				foreach (var recipe in allRecipes)
				{
					Console.WriteLine($"*****{counter}*****");
					Console.WriteLine(recipe);
					Console.WriteLine();

					counter++;
				}

			}
		}

        public void PromptToCreateRecipe()
        {
			Console.WriteLine("Create a new cookie recipe!");
			Console.WriteLine("Available ingredients are:");

			foreach (var ingredient in _ingredientsRegister)
			{
				Console.WriteLine(ingredient);
			}
        }

        public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}