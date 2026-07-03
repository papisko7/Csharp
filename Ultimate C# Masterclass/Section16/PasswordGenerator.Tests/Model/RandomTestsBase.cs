using NSubstitute;
using PasswordGenerator.Services.Abstractions;

namespace PasswordGenerator.Tests.Unit;

internal abstract class RandomTestsBase
{
	private protected const int STANDARD_ALPHABET_LENGTH = 36;
	private protected const int SPECIAL_ALPHABET_LENGTH = 50;
	private const int START_OF_ALPHABET = 0;

	protected IRandomProvider RandomProviderMock { get; private set; }

	[SetUp]
	public void BaseSetup()
	{
		RandomProviderMock = Substitute.For<IRandomProvider>();
	}

	protected void WillReturnCharacterIndicies(int alphabetLength, params int[] indicies)
	{
		RandomProviderMock
		.GenerateIntegerFromMinToLessThanMaxValue(START_OF_ALPHABET, alphabetLength)
		.Returns(indicies[0], indicies.Skip(1).ToArray());
	}
}