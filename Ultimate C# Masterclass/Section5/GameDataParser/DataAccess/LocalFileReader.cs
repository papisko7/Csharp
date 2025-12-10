using GameDataParser.DataAccess.Interfaces;

namespace GameDataParser.DataAccess
{
	public class LocalFileReader : ILocalFileReader
	{
		public string ReadFileContents(string filePath)
		{
			return File.ReadAllText(filePath);
		}
	}
}