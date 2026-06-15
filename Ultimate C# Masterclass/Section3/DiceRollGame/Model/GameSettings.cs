namespace DiceRollGame.Model;

public class GameSettings
{
	public int MinDiceValue { get; } = 1;

	public int MaxDiceValue { get; } = 6;

	public int TriesLimit { get; } = 3;
}