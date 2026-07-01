using PasswordGenerator;
using PasswordGenerator.Services;

IRandomProvider randomProvider = new RandomProvider();
ICharacterSetProvider characterSetProvider = new CharacterSetProvider();

var passwordGenerator = new PasswordGeneratorManager(randomProvider, characterSetProvider);

for (int i = 0; i < 10; i++)
{
	Console.WriteLine(passwordGenerator.Generate(5, 10, false));
}