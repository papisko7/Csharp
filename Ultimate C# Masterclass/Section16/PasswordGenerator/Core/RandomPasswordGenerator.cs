using PasswordGenerator.Services;

namespace PasswordGenerator.Core;

public class RandomPasswordGenerator(IRandomProvider _randomProvider, ICharacterSetProvider _characterSetProvider)
{
	public string Generate(int minValue, int maxValue, bool useSpecial)
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
		if (minValue < 1)
		{
			throw new ArgumentOutOfRangeException(
				$"Minimal value (left range) must be greater than 0");
		}
		if (maxValue < minValue)
		{
			throw new ArgumentOutOfRangeException(
				$"Minimal random (left range) value must be smaller than maximal value (right range)");
		}
	}
}