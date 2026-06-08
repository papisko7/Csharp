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

		[TestCase(0, new int[] { })]
		[TestCase(1, new int[] { 0 })]
		public void Generate_WhenInputIsZeroOrOne_ReturnsSequenceWithOnlyZero(int n, int[] expected)
		{
			// Act
			var result = Fibonacci.Generate(n);

			// Assert
			Assert.That(expected, Is.EqualTo(result));
		}

		[Test]
		public void Generate_WhenInputIsTwo_ReturnsFirstTwoFibonacciNumers()
		{
			// Arrange
			int n = 2;
			var expected = new List<int> { 0, 1 };

			// Act
			var result = Fibonacci.Generate(n);

			// Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase(3, new int[] { 0, 1, 1 })]
		[TestCase(6, new int[] { 0, 1, 1, 2, 3, 5 })]
		[TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
		public void Generate_WhenInputIsBetweenTwoAndFortySix_ReturnsCorrectSequence(int n, int[] expectedSequence)
		{
			// Act
			var result = Fibonacci.Generate(n);

			// Assert
			Assert.That(result, Is.EqualTo(expectedSequence));
		}
	}
}