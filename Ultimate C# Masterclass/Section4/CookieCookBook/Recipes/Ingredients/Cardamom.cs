using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients
{
	public class Cardamom : Ingredient
	{
		public override int ID => 6;

		public override string Name => "Cardamom";

		public override string PreperationInstruction => $"Take half a teaspoon. {base.PreperationInstruction}";
	}
}