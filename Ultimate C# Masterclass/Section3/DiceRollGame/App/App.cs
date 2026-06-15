using DiceRollGame.Model;
using DiceRollGame.Services;
using DiceRollGame.Ui;

namespace DiceRollGame.App;

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

		_writer.WriteLine($"Dice rolled. Guess what number it shows in {_gameSettings.TriesLimit} tries.");
		do
		{
			_writer.Write($"Enter your guess ({_gameSettings.MinDiceValue}-{_gameSettings.MaxDiceValue}): ");
			userInputString = _reader.ReadLine();

			if (!int.TryParse(userInputString, out int userInputInt)
				|| userInputInt < _gameSettings.MinDiceValue
				|| userInputInt > _gameSettings.MaxDiceValue)
			{
				_writer.WriteLine("Incorrect input");
			}

			else if (userInputInt == randomNumber)
			{
				_writer.WriteLine("Congratulations! You guessed the correct number.");
				return;
			}

			else
			{
				_writer.WriteLine("Wrong number");
				numberOfTries++;
			}
		} while (numberOfTries < _gameSettings.TriesLimit);

		_writer.WriteLine("You lose");
	}
}