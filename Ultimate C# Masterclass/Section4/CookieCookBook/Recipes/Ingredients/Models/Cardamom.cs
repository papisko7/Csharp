using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients.Models
{
	public class Cardamom : Ingredient
	{
		public override int Id => 6;

		public override string Name => "Cardamom";

		public override string PreperationInstruction => $"Take half a teaspoon. {base.PreperationInstruction}";
	}
}