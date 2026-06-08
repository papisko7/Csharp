using FibonacciGenerator;

var fibbonaciSequence = Fibonacci.Generate(7);

Console.Write('[');
foreach (var element in fibbonaciSequence)
{
	Console.Write(element + " ");
}

Console.Write(']');