namespace PasswordGenerator.Services;

public interface IRandomProvider
{
	int GenerateIntegerFromMinToMaxValue(int minValue, int maxValue);
}