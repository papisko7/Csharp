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
			var allIngredients = GetAllIngredients();
			var allIngredientsWithGivenId = allIngredients.Where(ingredient => ingredient.Id == ingredientId);

			if (allIngredientsWithGivenId.Count() > 1)
			{
				throw new InvalidOperationException($"More than one ingredient have Id equal to {ingredientId}.");
			}

			return allIngredientsWithGivenId.FirstOrDefault();
		}
	}
}