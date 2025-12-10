using GameDataParser.UserInteraction.Interfaces;

namespace GameDataParser.UserInteraction
{
	public class ConsoleUserInteractor : IUserInteractor
	{
		public void PrintError(string message)
		{
			var originalColor = Console.ForegroundColor;

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ForegroundColor = originalColor;
		}

		public void PrintMessage(string message)
		{
			Console.WriteLine(message);
		}

		public string ReadValidFilePath()
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
