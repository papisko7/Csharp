namespace CookieCookBook
{
	public static class FileManager
	{
		public static void CreateFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				Console.WriteLine("The file has already been created. New file won't be made.");
				return;
			}

			File.Create(filePath);
		}

		public static void ReadFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Console.WriteLine($"The file with given file path {filePath} does not exist. No file has been read.");
				return;
			}

			File.OpenRead(filePath);
			File.ReadAllText(filePath);
		}
	}
}