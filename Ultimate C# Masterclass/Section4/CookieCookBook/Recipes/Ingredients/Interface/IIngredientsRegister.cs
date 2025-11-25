using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients.Interface
{
	public interface IIngredientsRegister
	{
		IEnumerable<Ingredient> GetAllIngredients();

		Ingredient GetIngredientById(int ingredientId);
	}
}