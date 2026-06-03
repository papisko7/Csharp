using TicketsDataAggregator.Contracts;

namespace TicketsDataAggregator.UI;

public class ConsoleUserInterface : IUserInterface
{
	public string? GetInput(string promptMessage)
	{
		Console.WriteLine(promptMessage);
		return Console.ReadLine();
	}

	public void ShowMessage(string message)
	{
		Console.WriteLine(message);
	}

	public void WaitForKey(string? promptMessage = null)
	{
		if (!string.IsNullOrWhiteSpace(promptMessage))
		{
			promptMessage = "Invalid input! Please enter a valid file path." +
							@"Ex. C:\Users\admin\Downloads";
			Console.WriteLine(promptMessage);
		}
		Console.ReadKey();
	}
}