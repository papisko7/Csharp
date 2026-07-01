namespace PasswordGenerator.Core.Abstractions;

public interface IRandomPasswordGenerator
{
	string Generate(int minValue, int maxValue, bool useSpecial);
}