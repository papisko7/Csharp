try
{
	Console.WriteLine("Hello!");
	Console.Write("Input the first number: ");
	double num1 = Convert.ToDouble(Console.ReadLine() ?? "0.0");

	Console.Write("Input the second number: ");
	double num2 = Convert.ToDouble(Console.ReadLine() ?? "0.0");

	Console.WriteLine("What do you want to do with those numbers?");
	Console.WriteLine("[A]dd");
	Console.WriteLine("[S]ubtract");
	Console.WriteLine("[M]ultiply");
	string choice = Console.ReadLine() ?? "0";

	Operation(num1, num2, choice);
	Console.WriteLine("Press any key to close");
}
catch (Exception)
{
	Console.WriteLine("Invalid option");
}

double Operation(double num1, double num2, string choice)
{
	double result = 0.0;

	switch (choice.ToUpper())
	{
		case "A":
			result = num1 + num2;
			Console.WriteLine($"{num1} + {num2} = {result}");
			break;

		case "S":
			result = num1 - num2;
			Console.WriteLine($"{num1} - {num2} = {result}");
			break;

		case "M":
			result = num1 * num2;
			Console.WriteLine($"{num1} * {num2} = {result}");
			break;

		default:
			Console.WriteLine("Invalid option");
			break;
	}

	return result;
}