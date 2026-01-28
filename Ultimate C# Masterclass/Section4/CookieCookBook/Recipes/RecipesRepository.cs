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
			return _stringsRepository.Read(filePath)
				.Select(RecipeFromString).ToList();
		}

		private Recipe RecipeFromString(string recipeFromFile)
		{
			var ingredients = recipeFromFile.Split(SEPARATOR)
				.Select(int.Parse)
				.Select(_ingredientsRegister.GetIngredientById)
				.ToList();

			return new Recipe(ingredients);
		}

		public void WriteRecipes(string filePath, List<Recipe> allRecipes)
		{
			var recipesAsStrings = allRecipes.Select(recipe => string.Join(SEPARATOR, recipe.Ingredients
				.Select(r => r.Id)))
				.ToList();

			_stringsRepository.Write(filePath, recipesAsStrings);
		}
	}
}