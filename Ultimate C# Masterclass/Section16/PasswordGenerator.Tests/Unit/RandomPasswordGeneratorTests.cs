using NSubstitute;
using PasswordGenerator.Core;

namespace PasswordGenerator.Tests.Unit;

[TestFixture]
internal class RandomPasswordGeneratorTests : RandomTestsBase
{
	private RandomPasswordGenerator _randomPasswordGeneratorSut;

	[SetUp]
	public void Setup()
	{
		_randomPasswordGeneratorSut = new RandomPasswordGenerator(RandomProviderMock);
	}

	#region Happy Paths 

	[Test]
	public void Generate_PasswordGenerationWithoutSpecialCharacters_ReturnsExpectedPassword()
	{
		RandomProviderMock.GenerateIntegerFromMinToLessThanMaxValue(5, 11).Returns(6);
		WillReturnCharacterIndicies(STANDARD_ALPHABET_LENGTH, 0, 1, 2, 3, 4, 5);

		var result = _randomPasswordGeneratorSut.GeneratePassword(5, 10, useSpecial: false);

		Assert.That(result, Is.EqualTo("ABCDEF"));
	}

	[Test]
	public void Generate_PasswordGenerationWithSpecialCharacters_ReturnsExpectedPasswordIncludingSpecials()
	{
		RandomProviderMock.GenerateIntegerFromMinToLessThanMaxValue(10, 16).Returns(5);
		WillReturnCharacterIndicies(SPECIAL_ALPHABET_LENGTH, 23, 24, 25, 36, 37);

		var result = _randomPasswordGeneratorSut.GeneratePassword(10, 15, useSpecial: true);

		Assert.That(result, Is.EqualTo("XYZ!@"));
	}

	[Test]
	public void Generate_WhenMinAndMaxAreEqualToEachOther_ReturnsPasswordOfThatExactLength()
	{
		RandomProviderMock.GenerateIntegerFromMinToLessThanMaxValue(5, 6).Returns(5);
		WillReturnCharacterIndicies(STANDARD_ALPHABET_LENGTH, 0, 1, 2, 3, 4);

		var result = _randomPasswordGeneratorSut.GeneratePassword(5, 5, useSpecial: false);

		Assert.That(result, Is.EqualTo("ABCDE"));
	}

	#endregion

	#region Edge Cases 

	[Test]
	public void Generate_WhenMinValueIsLessThanOne_ThrowsArgumentOutOfRangeException()
	{
		var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
			_randomPasswordGeneratorSut.GeneratePassword(0, 5, useSpecial: false));

		Assert.That(exception.ParamName, Is.EqualTo("minValue"));
	}

	[Test]
	public void Generate_WhenMaxValueIsLessThanMinValue_ThrowsArgumentOutOfRangeException()
	{
		var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
			_randomPasswordGeneratorSut.GeneratePassword(10, 5, useSpecial: false));

		Assert.That(exception.ParamName, Is.EqualTo("maxValue"));
	}

	#endregion
}