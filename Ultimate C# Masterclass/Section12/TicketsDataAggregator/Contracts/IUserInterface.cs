namespace TicketsDataAggregator.Contracts;

public interface IUserInterface
{
	string? GetInput(string promptMessage);

	void ShowMessage(string message);

	void WaitForKey(string promptMessage = null);
}