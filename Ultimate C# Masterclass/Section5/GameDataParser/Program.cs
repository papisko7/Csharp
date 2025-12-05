using System.Text.Json;

Console.WriteLine("Enter the file name you want to read: ");
var fileName = Console.ReadLine();

var fileContents = File.ReadAllText(fileName);
var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

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