namespace DiceRollGame.Services;

public interface IDice
{
	int GetRandomNumberFromMinValueToMaxValue(int minValue, int maxValue);
}