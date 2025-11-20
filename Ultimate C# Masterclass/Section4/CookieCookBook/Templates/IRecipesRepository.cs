using CookieCookBook.Recipes;

namespace CookieCookBook.Templates
{
	public interface IRecipesRepository
	{
		public List<Recipe> ReadRecipes(string filePath);
	}
}