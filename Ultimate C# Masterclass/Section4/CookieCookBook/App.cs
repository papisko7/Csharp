namespace CookieCookBook.Appplication
{
	public class App
	{
		const string FILE_PATH = "recipes.txt";
		const FileFormat FILE_FORMAT = FileFormat.TXT;

		private static readonly Ingredient[] _listOfIngredients =
		{
		new Ingredient(1, "Wheat flour", "Sieve. Add to other ingredients."),
		new Ingredient(2, "Egg", "Crack and beat."),
		new Ingredient(3, "Sugar", "Measure and mix in."),
		new Ingredient(2, "Coconut flour", "Sieve. Add to other ingredients."),
		new Ingredient(3, "Butter", "Melt on low heat. Add to other ingredients."),
		new Ingredient(4, "Chocolate", "Melt in a water bath. Add to other ingredients."),
		new Ingredient(5, "Sugar", "Add to other ingredients."),
		new Ingredient(6, "Cardamom", "Take half a teaspoon. Add to other ingredients."),
		new Ingredient(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients."),
		new Ingredient(8, "Cocoa powder", "Add to other ingredients.")
		};

		public static void main(String[] args)
		{
			FileManager.CreateFile(FILE_PATH);
			FileManager.ReadFile(FILE_PATH);

			Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

			foreach (var ingredient in _listOfIngredients)
			{
				Console.WriteLine(ingredient);
			}

			string selectedIngredient = string.Empty;
			int ingredientId = 0;

            Console.WriteLine("Selecting ingredients for a new recipe.");
			do
			{
				Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
				selectedIngredient = Console.ReadLine();

				ingredientId = int.Parse(selectedIngredient);

				switch (ingredientId)
				{
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
						
						break;
                }

            } while (ingredientId > 0 && ingredientId <= 8);
			
		}
	}
}