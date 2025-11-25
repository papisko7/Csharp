using CookieCookBook.App.Interface;
using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.App
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

			foreach (var ingredient in _ingredientsRegister.GetAllIngredients())
			{
				Console.WriteLine(ingredient);
			}
		}

		public IEnumerable<Ingredient> ReadIngredientsFromUser()
		{
			bool shouldContinue = false;
			var ingredients = new List<Ingredient>();

			while (!shouldContinue)
			{
				Console.WriteLine("Add an ingredient by its Id, or type anything else if finished");
				var userInput = Console.ReadLine();

				if (int.TryParse(userInput, out int ingredientId))
				{
					var ingredient = _ingredientsRegister.GetIngredientById(ingredientId);

					if (ingredient != null)
					{
						ingredients.Add(ingredient);
					}
					else
					{
						Console.WriteLine("Ingredient with given Id does not exist.");
					}
				}
				else
				{
					shouldContinue = true;
				}
			}

			return ingredients;
		}

		public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}