using PasswordGenerator.Core.Abstractions;
using PasswordGenerator.Services.Abstractions;

namespace PasswordGenerator.Core;

public class RandomPasswordGenerator(IRandomProvider _randomProvider) : IRandomPasswordGenerator
{
	private const string STANDARD_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	private const string SPECIAL_CHARS = "!@#$%^&*()_-+=";

	public string Generate(int minValue, int maxValue,
		bool useSpecial)
	{
		ValidateRange(minValue, maxValue);

		var targetLength = _randomProvider.GenerateIntegerFromMinToMaxValue(minValue, maxValue + 1);

		var allowedCharacters = GetAllowedCharacters(useSpecial);

		return string.Create(targetLength, allowedCharacters, (span, alphabet) =>
		{
			for (var i = 0; i < span.Length; i++)
			{
				span[i] = alphabet[_randomProvider.GenerateIntegerFromMinToMaxValue(0, allowedCharacters.Length)];
			}
		});
	}

	private static void ValidateRange(int minValue, int maxValue)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(minValue, 1);
		ArgumentOutOfRangeException.ThrowIfLessThan(maxValue, minValue);
	}

	private static string GetAllowedCharacters(bool useSpecial)
	{
		return useSpecial ?
			$"{STANDARD_CHARS}{SPECIAL_CHARS}" :
			STANDARD_CHARS;
	}
}