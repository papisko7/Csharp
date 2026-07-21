const int PARSING_FAILURE = -1;

Console.WriteLine("Enter the word you want to search: ");
var searchedWord = Console.ReadLine();

ValidateSearchedWord(searchedWord);

Console.WriteLine("Enter the number of pages of data that you want to check to find your word:");
var numberOfPages = Console.ReadLine();
var parsednumberOfPages = ParseToInt(numberOfPages);

Console.WriteLine("Enter the number of quotes on each page of data:");
var numberOfQuotes = Console.ReadLine();
var parsedNumberOfQuotes = ParseToInt(numberOfQuotes);

Console.WriteLine("Enable parallel processing? (y/n): ");
var shouldEnableParallelProcessing = Console.ReadLine();

Console.WriteLine("Program is finished.");

static void ValidateSearchedWord(string? searchedWord)
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

static int ParseToInt(string? parsedString)
{
	if (!int.TryParse(parsedString, out int result) || result < 0)
	{
		Console.WriteLine("Please enter a valid whole number in order to proceed further.");
		return PARSING_FAILURE;
	}

	return result;
}