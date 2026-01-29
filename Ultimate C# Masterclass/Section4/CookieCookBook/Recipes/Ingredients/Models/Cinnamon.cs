using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients.Models
{
	public class Cinnamon : Ingredient
	{
		public override int Id => 7;

		public override string Name => "Cinnamon";

		public override string PreperationInstruction => $"Take one teaspoon. {base.PreperationInstruction}";
	}
}