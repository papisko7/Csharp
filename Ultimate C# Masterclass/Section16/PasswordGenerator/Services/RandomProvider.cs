using PasswordGenerator.Services.Abstractions;

namespace PasswordGenerator.Services;

public class RandomProvider : IRandomProvider
{
	private readonly Random _random = new();

	public int GenerateIntegerFromMinToLessThanMaxValue(int minValue, int maxValue)
	{
		return _random.Next(minValue, maxValue);
	}
}