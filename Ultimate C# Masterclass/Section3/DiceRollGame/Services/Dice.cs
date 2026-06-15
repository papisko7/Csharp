namespace DiceRollGame.Services;

public class Dice : IDice
{
	public int GetRandomNumberFromMinValueToMaxValue(int minValue, int maxValue)
	{
		return Random.Shared.Next(minValue,
			maxValue + 1);
	}
}