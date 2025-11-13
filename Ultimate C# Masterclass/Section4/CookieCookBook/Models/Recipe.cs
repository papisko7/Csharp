namespace CookieCookBook.Models
{
	public class Recipe
	{
		private List<Ingredient> _ingredients;

		public Recipe()
		{
			_ingredients = new List<Ingredient>();
		}

		public List<Ingredient> GetIngredients() => _ingredients;

		public void AddIngredient(Ingredient ingredient)
		{
			_ingredients.Add(ingredient);
		}
	}
}