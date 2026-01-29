namespace CookieCookBook.Recipes.Interface
{
	public interface IRecipesRepository
	{
		public List<Recipe> ReadRecipes(string filePath);

		public void WriteRecipes(string filePath, List<Recipe> allRecipes);
	}
}