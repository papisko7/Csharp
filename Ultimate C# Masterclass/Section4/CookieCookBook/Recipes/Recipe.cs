using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes
{
	public class Recipe
	{
		public IEnumerable<Ingredient> Ingredients { get; }

		public Recipe(IEnumerable<Ingredient> ingredients)
		{
			this.Ingredients = ingredients;
		}

		public override string ToString()
		{
			return string.Join(Environment.NewLine, Ingredients
				.Select(ingredient => $"{ingredient.Name}. {ingredient.PreperationInstruction}"));
		}
	}
}