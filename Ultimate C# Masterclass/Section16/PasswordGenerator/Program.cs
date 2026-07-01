using PasswordGenerator.Core;
using PasswordGenerator.Core.Abstractions;
using PasswordGenerator.Services;
using PasswordGenerator.Services.Abstractions;

IRandomProvider randomProvider = new RandomProvider();
IRandomPasswordGenerator passwordGenerator = new RandomPasswordGenerator(randomProvider);

for (int i = 0; i < 10; i++)
{
	Console.WriteLine(passwordGenerator.Generate(5, 10, false));
}