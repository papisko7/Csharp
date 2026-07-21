using Newtonsoft.Json;
using QuoteFinder.Dto;
using QuoteFinder.Mock;

Console.WriteLine("Enter the word you want to search: ");
var searchedWord = Console.ReadLine();

ValidateSearchedWord(searchedWord);

Console.WriteLine("Enter the number of pages of data that you want to check to find your word:");
var pagesToCheck = Console.ReadLine();
var parsedPagesToCheck = ParseToInt(pagesToCheck);

Console.WriteLine("Enter the number of quotes on each page of data:");
var quotesPerPage = Console.ReadLine();
var parsedQuotesPerPage = ParseToInt(quotesPerPage);

Console.WriteLine("Enable parallel processing? (y/n): ");
var shouldEnableParallelProcessing = Console.ReadLine();

var client = new MockQuotesApiDataReader();
for (var page = 1; page <= parsedPagesToCheck; page++)
{
	try
	{
		var response = await client.ReadAsync(page, parsedQuotesPerPage);
		var deserializeRoot = JsonConvert.DeserializeObject<Root>(response);

		ValidateApiResponse(deserializeRoot);
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error processing page {page}: {ex.Message}");
	}
}

Console.WriteLine("Program is finished.");
Console.ReadKey();

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
		throw new FormatException("Failed to parse user page user input.");
	}

	return result;
}

static void ValidateApiResponse(Root? response)
{
	if (response is not null)
	{
		if (response.Data is null)
		{
			throw new NullReferenceException("API returned no data.");
		}

		if (!response.Data.Any())
		{
			Console.WriteLine($"No data returned for page {response?.Pagination?.CurrentPage}");
		}
	}
	else
	{
		throw new NullReferenceException("Received null response.");
	}
}