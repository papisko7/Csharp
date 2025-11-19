using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients
{
	public class CocoaPowder : Ingredient
	{
		public override int ID => 8;

		public override string Name => "Cocoa Powder";

		public override string PreperationInstruction => $"{base.PreperationInstruction}";
	}
}