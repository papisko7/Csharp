using System.Diagnostics.Metrics;

namespace CookieCookBook
{
	public class FileManager
	{
		private static int _recipeNumber = 0;

		public static void CreateFile(string filePath, FileFormat fileFormat = FileFormat.TXT)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath);
				Console.WriteLine($"File created successfully at: {filePath}");
			}

			Console.WriteLine("The file has already been created. New file won't be made.");
		}

		public static void ReadFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Console.WriteLine($"The file with given file path {filePath} does not exist. No file has been read.");
				return;
			}

			string content = File.ReadAllText(filePath);

			Console.WriteLine($"Successfuly read file at {filePath}.");
			Console.WriteLine(content);
		}

		public static void WriteToFile(Recipe recipe, string filePath)
		{
			if (!File.Exists(filePath))
			{
				Console.WriteLine($"The file that you want to fill with content does not exist at: {filePath}");
				return;
			}

			File.AppendText($"***** {_recipeNumber} *****");
			File.AppendText(recipe.FormattedIngredientList());
		}
	}
}