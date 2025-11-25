using CookieCookBook.DataAccess.Interface;
using CookieCookBook.Recipes.Ingredients.Interface;
using CookieCookBook.Recipes.Ingredients.Interfaces;
using CookieCookBook.Recipes.Interface;

namespace CookieCookBook.Recipes
{
	public class RecipesRepository : IRecipesRepository
	{
		private const string SEPARATOR = ",";

		private IStringsRepository _stringsRepository;
		private IIngredientsRegister _ingredientsRegister;

		public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
		{
			_stringsRepository = stringsRepository;
			_ingredientsRegister = ingredientsRegister;
		}

		public List<Recipe> ReadRecipes(string filePath)
		{
			var recipesFromFile = _stringsRepository.Read(filePath);
			var recipes = new List<Recipe>();

			foreach (var recipeFromFile in recipesFromFile)
			{
				var recipe = RecipeFromString(recipeFromFile);
				recipes.Add(recipe);
			}

			return recipes;
		}

		private Recipe RecipeFromString(string recipeFromFile)
		{
			var textualIds = recipeFromFile.Split(SEPARATOR);
			var ingredients = new List<Ingredient>();

			foreach (var textualId in textualIds)
			{
				var id = int.Parse(textualId);
				var ingredient = _ingredientsRegister.GetIngredientById(id);

				ingredients.Add(ingredient);
			}

			return new Recipe(ingredients);
		}

		public void WriteRecipes(string filePath, List<Recipe> allRecipes)
		{
			var recipesAsStrings = new List<string>();

			foreach (var recipe in allRecipes)
			{
				var allIds = new List<int>();

				foreach (var ingredient in recipe.Ingredients)
				{
					allIds.Add(ingredient.Id);
				}

				recipesAsStrings.Add(string.Join(SEPARATOR, allIds));
			}

			_stringsRepository.Write(filePath, recipesAsStrings);
		}
	}
}