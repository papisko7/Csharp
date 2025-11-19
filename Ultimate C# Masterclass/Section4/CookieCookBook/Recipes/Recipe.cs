using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes
{
	internal class Recipe
	{
		private IEnumerable<Ingredient> Ingredients { get; }

		public Recipe(IEnumerable<Ingredient> ingredients)
		{
			this.Ingredients = ingredients;
		}
	}
}