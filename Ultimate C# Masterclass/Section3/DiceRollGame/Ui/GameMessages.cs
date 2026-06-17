namespace DiceRollGame.Ui;

public static class GameMessages
{
	public static string Welcome(int triesLimit) =>
		$"Dice rolled. Guess what number it shows in {triesLimit} tries.";

	public static string GuessPrompt(int min, int max) =>
		$"Enter your guess ({min}-{max}): ";

	public static string IncorrectInput => "Incorrect input";

	public static string Victory => "Congratulations! You guessed the correct number.";

	public static string WrongGuess => "Wrong number";

	public static string Defeat => "You lose";
}