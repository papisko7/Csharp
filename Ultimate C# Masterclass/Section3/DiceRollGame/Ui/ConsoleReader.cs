namespace DiceRollGame.Ui;

public class ConsoleReader : IConsoleReader
{
	public string ReadLine()
	{
		var input = Console.ReadLine();

		return !string.IsNullOrWhiteSpace(input)
			? input
			: string.Empty;
	}
}