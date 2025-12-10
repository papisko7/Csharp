using GameDataParser.DataAccess.Interfaces;
using GameDataParser.UserInteraction.Interfaces;
using System.Text.Json;

namespace GameDataParser.DataAccess
{
	public class VideoGamesDeserializer : IVideoGamesDeserializer
	{
		private readonly IUserInteractor _userInteractor;

		public VideoGamesDeserializer(IUserInteractor userInteractor)
		{
			_userInteractor = userInteractor;
		}

		public List<VideoGame> DeserializeFrom(string fileContents, string filePath)
		{
			try
			{
				return JsonSerializer.Deserialize<List<VideoGame>>(fileContents) ?? new List<VideoGame>();
			}
			catch (JsonException jex)
			{
				var originalColor = Console.ForegroundColor;

				_userInteractor.PrintError($"JSON in {filePath} file was not " +
					"in a valid format. JSON body:");
				_userInteractor.PrintError(fileContents);

				throw new JsonException($"{jex.Message} The file is: {filePath}", jex);
			}
		}
	}
}