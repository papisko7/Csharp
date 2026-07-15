Console.WriteLine("Enter the word you want to search: ");
var searchedWord = Console.ReadLine();

if (int.TryParse(searchedWord, out var word)
	|| string.IsNullOrWhiteSpace(searchedWord)
	|| WordHasSpecialCharacters(searchedWord))
{
	Console.WriteLine("The searched word has to be a single word only it cannot be a sentence, nor have any special characters (includes numbers). The word has to be provided and cannot be a whitespace.");
}

static bool WordHasSpecialCharacters(string word)
{
	return word.Any(character => !char.IsLetterOrDigit(character));
}