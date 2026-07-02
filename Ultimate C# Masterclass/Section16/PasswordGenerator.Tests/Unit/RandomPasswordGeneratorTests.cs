using NSubstitute;
using PasswordGenerator.Core;

namespace PasswordGenerator.Tests.Unit;

[TestFixture]
internal class RandomPasswordGeneratorTests : RandomTestsBase
{
	private const int STANDARD_ALPHABET_LENGTH = 36;
	private const int SPECIAL_ALPHABET_LENGTH = 50;

	private RandomPasswordGenerator _randomPasswordGeneratorSut;

	[SetUp]
	public void Setup()
	{
		_randomPasswordGeneratorSut = new RandomPasswordGenerator(RandomProviderMock);
	}

	#region Happy Paths (Ścieżki Optymistyczne)

	[Test]
	public void Generate_PasswordGenerationWithoutSpecialCharacters_ReturnsExpectedPassword()
	{
		RandomProviderMock.GenerateIntegerFromMinToMaxValue(5, 11).Returns(6);
		MockAlphabetSelections(STANDARD_ALPHABET_LENGTH);

		var result = _randomPasswordGeneratorSut.Generate(5, 10, useSpecial: false);

		Assert.That(result, Is.EqualTo("ABCDEF"));
	}

	[Test]
	public void Generate_PasswordGenerationWithSpecialCharacters_ReturnsExpectedPasswordIncludingSpecials()
	{
		RandomProviderMock.GenerateIntegerFromMinToMaxValue(2, 6).Returns(3);
		MockAlphabetSelections(SPECIAL_ALPHABET_LENGTH);

		var result = _randomPasswordGeneratorSut.Generate(2, 5, useSpecial: true);

		Assert.That(result, Is.EqualTo("ABC"));
	}

	[Test]
	public void Generate_WhenMinAndMaxAreEqualToEachOther_ReturnsPasswordOfThatExactLength()
	{
		RandomProviderMock.GenerateIntegerFromMinToMaxValue(5, 6).Returns(5);
		MockAlphabetSelections(STANDARD_ALPHABET_LENGTH);

		var result = _randomPasswordGeneratorSut.Generate(5, 5, useSpecial: false);

		Assert.That(result, Is.EqualTo("ABCDE"));
	}

	#endregion

	#region Edge Cases (Przypadki Brzegowe)

	[Test]
	public void Generate_WhenMinValueIsLessThanOne_ThrowsArgumentOutOfRangeException()
	{
		var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
			_randomPasswordGeneratorSut.Generate(0, 5, useSpecial: false));

		Assert.That(exception.ParamName, Is.EqualTo("minValue"));
	}

	[Test]
	public void Generate_WhenMaxValueIsLessThanMinValue_ThrowsArgumentOutOfRangeException()
	{
		var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
			_randomPasswordGeneratorSut.Generate(10, 5, useSpecial: false));

		Assert.That(exception.ParamName, Is.EqualTo("maxValue"));
	}

	#endregion
}