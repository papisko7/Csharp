using CookieCookBook.Recipes.Ingredients.Interface;
using CookieCookBook.Recipes.Ingredients.Interfaces;
using CookieCookBook.Recipes.Ingredients.Models;

namespace CookieCookBook.Recipes.Ingredients
{
	public class IngredientsRegister : IIngredientsRegister
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

		public Ingredient GetIngredientById(int ingredientId)
		{
			return GetAllIngredients()
				.FirstOrDefault(ingredient => ingredient.Id == ingredientId);
		}
	}
}