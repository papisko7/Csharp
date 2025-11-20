using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook.Recipes.Ingredients
{
	public class Butter : Ingredient
	{
		public override int Id => 3;

		public override string Name => "Butter";

		public override string PreperationInstruction => $"Melt on low heat. {base.PreperationInstruction}";
	}
}