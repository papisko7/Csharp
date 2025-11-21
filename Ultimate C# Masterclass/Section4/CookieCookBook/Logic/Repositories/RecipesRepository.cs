using CookieCookBook.FileManagement.Interface;
using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes.Ingredients.Interfaces;
using CookieCookBook.Templates;

namespace CookieCookBook.Logic.Repositories
{
	public class RecipesRepository : IRecipesRepository
	{
		private IStringsRepository _stringsRepository;

		public RecipesRepository(IStringsRepository stringsRepository)
		{
			_stringsRepository = stringsRepository;
		}

		public List<Recipe> ReadRecipes(string filePath)
		{
			return new List<Recipe>()
			{
				new Recipe(new List<Ingredient>()
				{
					new WheatFlour(),
					new Sugar(),
					new Cardamom(),
				}),

				new Recipe(new List<Ingredient>()
				{
					new Chocolate(),
					new Sugar(),
					new CoconutFlour(),
				}),
			};
		}

        public void WriteRecipes(string filePath, List<Recipe> allRecipes)
        {
			var recipesAsStrings = new List<string>();

			foreach (var recipe in allRecipes)
			{
				var allIds = new List<int>();

				foreach(var ingredient in recipe.Ingredients)
				{
					allIds.Add(ingredient.Id);
				}

				recipesAsStrings.Add(string.Join(",", allIds));
			}

			_stringsRepository.Write(filePath, recipesAsStrings);
		}
    }
}