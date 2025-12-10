namespace GameDataParser.UserInteraction.Interfaces
{
	public interface IUserInteractor
	{
		public string ReadValidFilePath();

		public void PrintMessage(string message);

		public void PrintError(string message);
	}
}