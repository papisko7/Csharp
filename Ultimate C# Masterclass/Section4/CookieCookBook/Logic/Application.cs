using CookieCookBook.Recipes;
using CookieCookBook.Templates;

namespace CookieCookBook.Logic
{
	public class Application
	{
		private readonly IRecipesRepository _recipesRepository;
		private readonly IRecipesUserInteraction _recipesConsoleUserInteraction;


		public Application(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
		{
			_recipesRepository = recipesRepository;
			_recipesConsoleUserInteraction = recipesUserInteraction;
		}

		public void Run(string filePath)
		{
			var allRecipes = _recipesRepository.ReadRecipes(filePath);
			
			_recipesConsoleUserInteraction.PrintExistingRecipes(allRecipes);
			_recipesConsoleUserInteraction.PromptToCreateRecipe();

			var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

			if (ingredients.Count() > 0)
			{
				var recipe = new Recipe(ingredients);
				allRecipes.Add(recipe);
				_recipesRepository.WriteRecipes(filePath, allRecipes);

				_recipesConsoleUserInteraction.ShowMessage("Recipe added");
				_recipesConsoleUserInteraction.ShowMessage(recipe.ToString());
			}

			else
			{
				_recipesConsoleUserInteraction.ShowMessage("No ingredients have been selected. " +
					"Recipe will not be saved.");
			}

			//_recipesConsoleUserInteraction.Exit();
		}
	}
}