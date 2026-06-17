using DiceRollGame.Model;
using DiceRollGame.Services;
using DiceRollGame.Ui;

namespace DiceRollGame.Application;

public class App(GameSettings gameSettings, IDice dice,
	IConsoleReader reader, IConsoleWriter writer)
{
	private readonly GameSettings _gameSettings = gameSettings;

	private readonly IDice _dice = dice;
	private readonly IConsoleReader _reader = reader;
	private readonly IConsoleWriter _writer = writer;

	public void Start()
	{
		var randomNumber = _dice.GetRandomNumberFromMinValueToMaxValue(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue);
		var numberOfTries = 0;
		string userInputString;

		_writer.WriteLine(GameMessages.Welcome(_gameSettings.TriesLimit));
		do
		{
			userInputString = ReadGuessFromConsole();

			if (IsInputValid(userInputString, out int userInputInt))
			{
				_writer.WriteLine(GameMessages.IncorrectInput);
			}

			else if (userInputInt == randomNumber)
			{
				_writer.WriteLine(GameMessages.Victory);
				return;
			}

			else
			{
				_writer.WriteLine(GameMessages.WrongGuess);
				numberOfTries++;
			}
		} while (numberOfTries < _gameSettings.TriesLimit);

		_writer.WriteLine(GameMessages.Defeat);
	}

	private string ReadGuessFromConsole()
	{
		_writer.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
		return _reader.ReadLine();
	}

	private bool IsInputValid(string userInputString, out int userInputInt)
	{
		return !int.TryParse(userInputString, out userInputInt)
				|| userInputInt < _gameSettings.MinDiceValue
				|| userInputInt > _gameSettings.MaxDiceValue;
	}
}