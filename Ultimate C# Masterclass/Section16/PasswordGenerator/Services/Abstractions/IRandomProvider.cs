namespace PasswordGenerator.Services.Abstractions;

public interface IRandomProvider
{
	int GenerateIntegerFromMinToLessThanMaxValue(int minValue, int maxValue);
}