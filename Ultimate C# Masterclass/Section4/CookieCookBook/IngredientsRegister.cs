using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes.Ingredients.Interfaces;

namespace CookieCookBook
{
	public class IngredientsRegister
	{
		public IEnumerable<Ingredient> GetAllIngredients()
		{
			return new List<Ingredient>
			{
				new WheatFlour(),
				new CoconutFlour(),
				new Butter(),
				new Chocolate(),
				new Sugar(),
				new Cardamom(),
				new Cinnamon(),
				new CocoaPowder()
			};
		}
	}
}