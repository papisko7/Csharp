namespace CookieCookBook
{
	public class IngredientsRegister
	{
		public IEnumerable<string> GetAllIngredients()
		{
			return new List<string>
			{
				"Flour",
				"Sugar",
				"Butter",
				"Eggs",
				"Baking Powder",
				"Vanilla Extract",
				"Chocolate Chips",
				"Oats",
				"Cinnamon",
				"Nuts"
			};
		}
	}
}