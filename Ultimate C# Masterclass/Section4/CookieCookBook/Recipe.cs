using System.Text;

namespace CookieCookBook
{
	public class Recipe
	{
		private static List<Ingredient> IngredientsList { get; set; }

		public string FormattedIngredientList()
		{
			StringBuilder stringBuilder = new StringBuilder();

			foreach (var ingredient in IngredientsList)
			{
				stringBuilder.AppendLine($"{ingredient.GetName()}. {ingredient.GetInstructions()}");
			}

			return stringBuilder.ToString();
		}
	}
}