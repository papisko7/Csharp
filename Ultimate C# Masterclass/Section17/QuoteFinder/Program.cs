Console.WriteLine("Enter the word you want to search: ");
var searchedWord = Console.ReadLine();

ValidateInput(searchedWord);

Console.WriteLine("");
var numberOfPages = Console.Read();

static void ValidateInput(string? searchedWord)
{
	if (string.IsNullOrWhiteSpace(searchedWord))
	{
		Console.WriteLine("The searched word cannot be null or a whitespace.");
		return;
	}

	if (WordHasSpacesAndContainsLetters(searchedWord))
	{
		Console.WriteLine("The searched word has to be a single word. The word cannot contain any special characters including numbers.");
		return;
	}
}

static bool WordHasSpacesAndContainsLetters(string searchedWord)
{
	return searchedWord.Any(character => char.IsWhiteSpace(character)
	|| !char.IsLetter(character));
}