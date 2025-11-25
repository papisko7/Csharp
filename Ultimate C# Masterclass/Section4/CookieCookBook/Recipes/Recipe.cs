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
			var steps = new List<string>();

			foreach (var ingredient in Ingredients)
			{
				steps.Add($"{ingredient.Name}. {ingredient.PreperationInstruction}");
			}

			return string.Join(Environment.NewLine, steps);
		}
	}
}