using System.Text.Json;

namespace GameDataParserNamespace
{
	public class GameDataParser
	{
		public void Run()
		{
			string? filePath = ReadFilePathFromUser();
			string? fileContents = File.ReadAllText(filePath);
			List<VideoGame> videoGames = DeserializeVideoGamesFrom(fileContents, filePath);

			PrintGames(videoGames);
		}

		private static void PrintGames(List<VideoGame> videoGames)
		{
			if (videoGames.Count > 0)
			{
				Console.WriteLine();
				Console.WriteLine("Loaded games are: ");

				foreach (var videoGame in videoGames)
				{
					Console.WriteLine(videoGame);
				}
			}
			else
			{
				Console.WriteLine("No games are present in the input file.");
			}
		}

		private List<VideoGame> DeserializeVideoGamesFrom(string fileContents, string filePath)
		{
			try
			{
				return JsonSerializer.Deserialize<List<VideoGame>>(fileContents) ?? new List<VideoGame>();
			}
			catch (JsonException jex)
			{
				var originalColor = Console.ForegroundColor;

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"JSON in {filePath} file was not " +
					"in a valid format. JSON body:");
				Console.WriteLine(fileContents);
				Console.ForegroundColor = originalColor;

				throw new JsonException($"{jex.Message} The file is: {filePath}", jex);
			}
		}

		private string ReadFilePathFromUser()
		{
			var isFilePathValid = false;
			var userFilePath = string.Empty;

			do
			{
				Console.WriteLine("Enter the file path you want to read (or file name if the file is in the project file): ");
				userFilePath = Console.ReadLine();

				if (userFilePath is null)
				{
					Console.WriteLine("File path cannot be null!");
				}

				else if (userFilePath.Equals(string.Empty))
				{
					Console.WriteLine("File path cannot be empty!");
				}

				else if (!File.Exists(userFilePath))
				{
					Console.WriteLine("File of a given path does not exist!");
				}
				isFilePathValid = true;
			} while (!isFilePathValid);

			return userFilePath;
		}
	}
}