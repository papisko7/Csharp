using System.Text.Json;

string fileContents = default;
string filePath = default;
bool isValidInput = false;
List<VideoGame> videoGames = default;

do
{
	try
	{
		Console.WriteLine("Enter the file path you want to read (or file name if the file is in the project file): ");
		filePath = Console.ReadLine();

		fileContents = File.ReadAllText(filePath);
		isValidInput = true;
	}
	catch (ArgumentNullException)
	{
		Console.WriteLine("File name is null.");
	}
	catch (ArgumentException)
	{
		Console.WriteLine("File name is empty.");
	}
	catch (FileNotFoundException)
	{
		Console.WriteLine("File of a given name does not exist");
	}
} while (!isValidInput);

try
{
	videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
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