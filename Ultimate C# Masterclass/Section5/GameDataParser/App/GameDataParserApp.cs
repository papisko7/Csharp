using GameDataParser.DataAccess.Interfaces;
using GameDataParser.UserInteraction.Interfaces;

namespace GameDataParser.App
{
	public class GameDataParserApp
	{
		private readonly IUserInteractor _userInteractor;
		private readonly ILocalFileReader _localFileReader;
		private readonly IVideoGamesDeserializer _videoGamesDeserializer;
		private readonly IGamesPrinter _gamesPrinter;

		public GameDataParserApp(IUserInteractor userInteractor, ILocalFileReader localFileReader, IVideoGamesDeserializer videoGamesDeserializer, IGamesPrinter gamesPrinter)
		{
			_userInteractor = userInteractor;
			_localFileReader = localFileReader;
			_videoGamesDeserializer = videoGamesDeserializer;
			_gamesPrinter = gamesPrinter;
		}

		public void Run()
		{
			var filePath = _userInteractor.ReadValidFilePath();
			var fileContents = _localFileReader.ReadFileContents(filePath);
			var videoGames = _videoGamesDeserializer.DeserializeFrom(fileContents, filePath);

			_gamesPrinter.Print(videoGames);
		}
	}
}