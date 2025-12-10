using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Logging;
using GameDataParser.UserInteraction;

ConsoleUserInteractor userInteractor = new ConsoleUserInteractor();
GameDataParserApp app = new GameDataParserApp(userInteractor, new LocalFileReader(), new VideoGamesDeserializer(userInteractor), new GamesPrinter(userInteractor));
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