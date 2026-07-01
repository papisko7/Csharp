namespace PasswordGenerator.Services.Abstractions;

public interface IRandomProvider
{
	int GenerateIntegerFromMinToMaxValue(int minValue, int maxValue);
}