using DiceRollGame.Application;
using DiceRollGame.Model;
using DiceRollGame.Services;
using DiceRollGame.Ui;
using NSubstitute;

namespace DiceRollGame.Tests;

[TestFixture]
public class AppTests
{
	private GameSettings _gameSettings;
	private App _app;

	private IDice _dice;
	private IConsoleReader _consoleReader;
	private IConsoleWriter _consoleWriter;


	[SetUp]
	public void Setup()
	{
		_gameSettings = new GameSettings();
		_dice = Substitute.For<IDice>();
		_consoleReader = Substitute.For<IConsoleReader>();
		_consoleWriter = Substitute.For<IConsoleWriter>();
		_app = new App(_gameSettings, _dice, _consoleReader, _consoleWriter);
	}

	[Test]
	public void Start_UserGuessesTheNumberOnHisFirstTry_DeclaresUserAsWinner()
	{
		// Arrange
		_dice.GetRandomNumberFromMinValueToMaxValue(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue).Returns(4);
		_consoleReader.ReadLine().Returns("4");

		// Act
		_app.Start();

		// Assert
		_consoleWriter.Received(1).WriteLine("Congratulations! You guessed the correct number.");
	}

	[Test]
	public void Start_UserGuessesTheNumberOnHisLastTry_DeclaresWrongGuessTwiceAndOneVictoryMessages()
	{
		//Arrange
		_dice.GetRandomNumberFromMinValueToMaxValue(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue).Returns(6);
		_consoleReader.ReadLine().Returns("1", "4", "6");

		// Act
		_app.Start();

		// Assert
		Received.InOrder(() =>
		{
			_consoleWriter.WriteLine(GameMessages.Welcome(_gameSettings.TriesLimit));
			_consoleWriter.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
			_consoleWriter.WriteLine(GameMessages.WrongGuess);
			_consoleWriter.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
			_consoleWriter.WriteLine(GameMessages.WrongGuess);
			_consoleWriter.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
			_consoleWriter.WriteLine(GameMessages.Victory);
		});
	}

	[Test]
	public void Start_UserDidNotGuessTheAnswer_DeclaresUserAsLoser()
	{
		_dice.GetRandomNumberFromMinValueToMaxValue(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue).Returns(5);
		_consoleReader.ReadLine().Returns("1", "2", "3");

		// Act
		_app.Start();

		// Assert
		Received.InOrder(() =>
		{
			_consoleWriter.WriteLine(GameMessages.Welcome(_gameSettings.TriesLimit));
			_consoleWriter.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
			_consoleWriter.WriteLine(GameMessages.WrongGuess);
			_consoleWriter.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
			_consoleWriter.WriteLine(GameMessages.WrongGuess);
			_consoleWriter.Write(GameMessages.GuessPrompt(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue));
			_consoleWriter.WriteLine(GameMessages.WrongGuess);
			_consoleWriter.WriteLine(GameMessages.Defeat);
		});
	}

	[TestCase("a")]
	[TestCase("!@#")]
	[TestCase("-1")]
	[TestCase("-999")]
	[TestCase("0")]
	[TestCase("999")]
	[TestCase("")]
	[TestCase(" ")]
	public void Start_InputIsInvalid_ShowsIncorrectInputMessage(string invalidInput)
	{
		// Arrange
		_dice.GetRandomNumberFromMinValueToMaxValue(Arg.Any<int>(), Arg.Any<int>()).Returns(1);
		_consoleReader.ReadLine().Returns(invalidInput, "1");

		// Act
		_app.Start();

		// Assert
		_consoleWriter.Received().WriteLine(GameMessages.IncorrectInput);
		_consoleWriter.Received().WriteLine(GameMessages.Victory);
	}

	[TestCase(1)]
	[TestCase(6)]
	public void Start_UserEntersBoundaryValues_DeclaresUserAsWinner(int boundaryValue)
	{
		// Arrange
		_dice.GetRandomNumberFromMinValueToMaxValue(_gameSettings.MinDiceValue, _gameSettings.MaxDiceValue)
			.Returns(boundaryValue);
		_consoleReader.ReadLine().Returns(boundaryValue.ToString());

		// Act
		_app.Start();

		// Assert
		_consoleWriter.Received().WriteLine(GameMessages.Victory);
	}
}