using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients
{
	public class Sugar : Ingredient
	{
		public override int ID => 5;

		public override string Name => "Sugar";

		public string PreperationInstruction => $"{base.PreperationInstruction}";
	}
}