namespace GameDataParser.DataAccess.Interfaces
{
	public interface IVideoGamesDeserializer
	{
		public List<VideoGame> DeserializeFrom(string fileContents, string filePath);
	}
}