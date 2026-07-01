namespace PasswordGenerator.Services;

public class RandomProvider : IRandomProvider
{
	private readonly Random _random = new Random();

	public int GenerateIntegerFromMinToMaxValue(int minValue, int maxValue)
	{
		return _random.Next(minValue, maxValue);
	}
}