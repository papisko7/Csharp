using CookieCookBook.Recipes;
using CookieCookBook.Recipes.Ingredients;
using CookieCookBook.Recipes.Ingredients.Interfaces;
using CookieCookBook.Templates;

namespace CookieCookBook.Logic
{
	public class RecipesRepository : IRecipesRepository
	{
		public List<Recipe> ReadRecipes(string filePath)
		{
			return new List<Recipe>()
			{
				new Recipe(new List<Ingredient>()
				{
					new WheatFlour(),
					new Sugar(),
					new Cardamom(),
				}),

				new Recipe(new List<Ingredient>()
				{
					new Chocolate(),
					new Sugar(),
					new CoconutFlour(),
				}),
			};
		}
	}
}