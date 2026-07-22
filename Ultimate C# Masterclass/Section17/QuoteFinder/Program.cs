using Newtonsoft.Json;
using QuoteFinder.Dto;
using QuoteFinder.Mock;

const string PAGES_TO_CHECK_PROMPT = "Enter the number of pages of data that you want to check to find your word:";
const string QUOTES_PER_PAGE_PROMPT = "Enter the number of quotes on each page of data:";

var searchedWord = ReadValidSearchedWord();
var parsedPagesToCheck = ReadIntFromConsole(PAGES_TO_CHECK_PROMPT);
var parsedQuotesPerPage = ReadIntFromConsole(QUOTES_PER_PAGE_PROMPT);

Console.WriteLine("Enable parallel processing? (y/n): ");
var shouldEnableParallelProcessing = Console.ReadLine();

var client = new HttpClient();
var clientMock = new MockQuotesApiDataReader();

for (var page = 1; page <= parsedPagesToCheck; page++)
{
	var url = $"https://quote-garden.onrender.com/api/v3/quotes?limit={parsedQuotesPerPage}&page={page}";
	var jsonResponse = await GetResponse(url, page, parsedQuotesPerPage, client, clientMock);
	var deserializedRoot = JsonConvert.DeserializeObject<Root>(jsonResponse);

	if (!IsApiResponseValid(deserializedRoot, page))
	{
		continue;
	}
}

Console.WriteLine("Program is finished.");
Console.ReadKey();

static string ReadValidSearchedWord()
{
	Console.WriteLine("Enter the word you want to search: ");
	var searchedWord = Console.ReadLine();

	while (!IsSearchedWordValid(searchedWord))
	{
		Console.WriteLine("Please enter a valid word:");
		searchedWord = Console.ReadLine();
	}

	return searchedWord;
}

static bool IsSearchedWordValid(string? searchedWord)
{
	if (string.IsNullOrWhiteSpace(searchedWord))
	{
		Console.WriteLine("The searched word cannot be null or a whitespace.");
		return false;
	}

	if (WordHasSpacesAndContainsLetters(searchedWord))
	{
		Console.WriteLine("The searched word has to be a single word. The word cannot contain any special characters including numbers.");
		return false;
	}

	return true;
}

static bool WordHasSpacesAndContainsLetters(string searchedWord)
{
	return searchedWord.Any(character => char.IsWhiteSpace(character)
	|| !char.IsLetter(character));
}

static int ReadIntFromConsole(string prompt)
{
	int result;
	Console.WriteLine(prompt);

	while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
	{
		Console.WriteLine("Invalid input. Please enter a valid positive number:");
	}

	return result;
}

static async Task<string> GetResponse(string url, int page, int parsedQuotesPerPage, HttpClient client, MockQuotesApiDataReader clientMock)
{
	try
	{
		var httpResponse = await client.GetAsync(url);
		if (httpResponse.IsSuccessStatusCode)
		{
			return await httpResponse.Content.ReadAsStringAsync();
		}
		else
		{
			Console.WriteLine($"Page {page}: API return code {httpResponse.StatusCode}. Falling back to mock data.");
			return await clientMock.ReadAsync(page, parsedQuotesPerPage);
		}
	}
	catch (HttpRequestException ex)
	{
		Console.WriteLine($"Page {page}: Network error ({ex.Message}). Falling back to mock data.");
		return await clientMock.ReadAsync(page, parsedQuotesPerPage);
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Error processing page {page}: {ex.Message}");
		return await clientMock.ReadAsync(page, parsedQuotesPerPage);
	}
}

static bool IsApiResponseValid(Root? response, int pageNumber)
{
	if (response is null)
	{
		Console.WriteLine($"Page {pageNumber}: Received null or invalid JSON response.");
		return false;
	}

	if (response.Data is null || !response.Data.Any())
	{
		Console.WriteLine($"Page {pageNumber}: No quotes found in response.");
		return false;
	}

	return true;
}