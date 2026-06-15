namespace DiceRollGame.Ui;

public class ConsoleWriter : IConsoleWriter
{
	public void WriteLine(string message)
	{
		Console.WriteLine(message);
	}

	public void Write(string message)
	{
		Console.Write(message);
	}
}