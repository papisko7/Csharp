using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients.Models
{
	public class CocoaPowder : Ingredient
	{
		public override int Id => 8;

		public override string Name => "Cocoa Powder";

		public override string PreperationInstruction => $"{base.PreperationInstruction}";
	}
}