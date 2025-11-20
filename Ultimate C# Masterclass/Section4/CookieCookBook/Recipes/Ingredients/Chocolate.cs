using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients
{
	public class Chocolate : Ingredient
	{
		public override int Id => 4;

		public override string Name => "Chocolate";

		public override string PreperationInstruction => $"Melt in a water bath. {base.PreperationInstruction}";
	}
}