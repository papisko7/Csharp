using PasswordGenerator.Services;

namespace PasswordGenerator.Core;

public class RandomPasswordGenerator(IRandomProvider _randomProvider, ICharacterSetProvider _characterSetProvider)
{
	public string Generate(int minValue, int maxValue,
		bool useSpecial)
	{
		ValidateRange(minValue, maxValue);

		var targetLength = _randomProvider.GenerateIntegerFromMinToMaxValue(minValue, maxValue + 1);

		var allowedCharacters = _characterSetProvider.GetAllowedCharacters(useSpecial);

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
}