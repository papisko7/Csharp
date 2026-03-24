namespace StarWarsPlanetsData.UserInteraction
{
	public class ConsoleUserInteractor : IUserInteractor
	{
		public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}

		public string? GetUserInput()
		{
			return Console.ReadLine();
		}
	}
}
