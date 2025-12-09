using GameDataParserNamespace;
using LoggerNamespace;

GameDataParser app = new GameDataParser();
Logger logger = new Logger("log.txt");

try
{
	app.Run();
}
catch (Exception ex)
{
	Console.WriteLine($"An error occurred: {ex.Message}");
	logger.Log(ex);
}