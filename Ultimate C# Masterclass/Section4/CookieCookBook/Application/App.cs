using CookieCookBook.Models;

namespace CookieCookBook.Application
{
	public static class App
	{
		private static readonly Ingredient[] _ingredients =
		{
			new Ingredient(1, "Wheat flour", "Sieve. Add to other ingredients."),
			new Ingredient(2, "Coconut flour", "Sieve. Add to other ingredients."),
			new Ingredient(3, "Butter", "Melt on low heat. Add to other ingredients."),
			new Ingredient(4, "Chocolate", "Melt in a water bath. Add to other ingredients."),
			new Ingredient(5, "Sugar", "Add to other ingredients."),
			new Ingredient(6, "Cardamom", "Take half a teaspoon. Add to other ingredients."),
			new Ingredient(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients."),
			new Ingredient(8, "Cocoa powder", "Add to other ingredients."),
		};

		private static List<Recipe> _recipes = new List<Recipe>();

		public static void Main(string[] args)
		{
			Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

			foreach (var ingredient in _ingredients)
			{
				Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
			}

			do
			{
				Console.WriteLine("“Add an ingredient by its ID or type anything else if finished.”");
				var ingredientId = Console.Read();

				switch (ingredientId)
				{
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
						var selectedIngredient = _ingredients.First(i => i.Id == ingredientId);

						break;
					default:
						Console.WriteLine("Your cookie recipe is ready! Here are the instructions:");
						foreach (var instruction in _recipes)
						{
							Console.WriteLine(instruction);
						}
						return;
				}
			} while (true);
		}
	}
}