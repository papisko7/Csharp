using NSubstitute;
using PasswordGenerator.Services.Abstractions;

namespace PasswordGenerator.Tests.Unit;

internal abstract class RandomTestsBase
{
	protected IRandomProvider RandomProviderMock { get; private set; }

	[SetUp]
	public void BaseSetup()
	{
		RandomProviderMock = Substitute.For<IRandomProvider>();
	}

	protected void MockAlphabetSelections(int alphabetLength)
	{
		var currentCharacterIndex = 0;
		RandomProviderMock
			.GenerateIntegerFromMinToMaxValue(0, alphabetLength)
			.Returns(_ => currentCharacterIndex++);
	}
}