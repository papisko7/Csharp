using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.App.Interface
{
	public interface IRecipesUserInteraction
	{
		public void ShowMessage(string message);

		public void Exit();

		public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);

		public void PromptToCreateRecipe();

		IEnumerable<Ingredient> ReadIngredientsFromUser();
	}
}