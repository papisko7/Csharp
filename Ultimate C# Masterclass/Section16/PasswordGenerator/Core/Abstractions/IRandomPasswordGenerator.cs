namespace PasswordGenerator.Core.Abstractions;

public interface IRandomPasswordGenerator
{
	string GeneratePassword(int minValue, int maxValue, bool useSpecial);
}