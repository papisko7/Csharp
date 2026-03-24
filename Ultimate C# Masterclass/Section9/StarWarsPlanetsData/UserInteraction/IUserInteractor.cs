namespace StarWarsPlanetsData.UserInteraction
{
	public interface IUserInteractor
	{
		void ShowMessage(string message);

		string? GetUserInput();
	}
}
