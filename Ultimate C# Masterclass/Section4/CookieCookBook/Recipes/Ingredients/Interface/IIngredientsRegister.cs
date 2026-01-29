using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients.Interface
{
	public interface IIngredientsRegister
	{
		public IEnumerable<Ingredient> GetAllIngredients();

		public Ingredient GetIngredientById(int ingredientId);
	}
}