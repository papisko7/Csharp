namespace FibonacciGenerator.UnitTests
{
	[TestFixture]
	public class FibonacciTests
	{
		[TestCase(-1)]
		[TestCase(-17)]
		[TestCase(-30)]
		public void Generate_WhenInputIsLessThanZero_ThrowsArgumentException(int n)
		{
			Assert.Throws<ArgumentException>(() => Fibonacci.Generate(n));
		}

		[TestCase(47)]
		[TestCase(73)]
		[TestCase(100)]
		public void Generate_WhenInputIsGreaterThanFortySix_ThrowsArgumentException(int n)
		{
			Assert.Throws<ArgumentException>(() => Fibonacci.Generate(n));
		}

		// Fixed the method name to reflect reality accuracy
		[TestCase(0, new int[] { })]
		[TestCase(1, new int[] { 0 })]
		[TestCase(2, new int[] { 0, 1 })]
		public void Generate_WhenInputIsZeroOneOrTwo_ReturnsCorrectSequence(int n, int[] expected)
		{
			// Act
			var result = Fibonacci.Generate(n);

			// Assert: Swapped to (actual, expected) convention
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(3, new int[] { 0, 1, 1 })]
		[TestCase(6, new int[] { 0, 1, 1, 2, 3, 5 })]
		[TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
		public void Generate_WhenInputIsBetweenTwoAndFortySix_ReturnsCorrectSequence(int n, int[] expectedSequence)
		{
			// Act
			var result = Fibonacci.Generate(n);

			// Assert: Swapped to (actual, expected) convention
			Assert.That(result, Is.EqualTo(expectedSequence));
		}

		// Fixed name to clearly state the expected behavior/outcome
		[Test]
		public void Generate_WhenInputIsFortySix_ReturnsSequenceEndingWithMaxFibonacciNumber()
		{
			// Arrange
			const int expectedLastNumber = 1134903170;

			// Act
			var result = Fibonacci.Generate(46);

			// Assert
			Assert.That(result.Last(), Is.EqualTo(expectedLastNumber));
		}
	}
}