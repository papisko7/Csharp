using Newtonsoft.Json;
using QuoteFinder.Data;
using QuoteFinder.Dto;
using QuoteFinder.Mock;
using System.Diagnostics;
using System.Text.RegularExpressions;

var searchedWord = ReadValidSearchedWord();
var parsedPagesToCheck = ReadIntFromConsole("Enter the number of pages of data that you want to check to find your word:");
var parsedQuotesPerPage = ReadIntFromConsole("Enter the number of quotes on each page of data:");

Console.WriteLine("Enable parallel processing? (y/n): ");
var shouldEnableParallelProcessing = Console.ReadLine();

var stopWatch = new Stopwatch();
var client = new HttpClient();
var clientMock = new MockQuotesApiDataReader();

stopWatch.Start();
for (var page = 1; page <= parsedPagesToCheck; page++)
{
	await ProcessPageAsync(searchedWord, client, clientMock, page, parsedQuotesPerPage);
}
stopWatch.Stop();

Console.WriteLine("RunTime: " + stopWatch.Elapsed);
Console.WriteLine("Program is finished.");
Console.ReadKey();

static async Task<PageResult> ProcessPageAsync(string searchedWord, HttpClient client, MockQuotesApiDataReader clientMock, int page, int parsedQuotesPerPage)
{
	var url = $"https://quote-garden.onrender.com/api/v3/quotes?limit={parsedQuotesPerPage}&page={page}";
	var jsonResponse = await GetResponse(url, page, parsedQuotesPerPage, client, clientMock);
	var deserializedRoot = JsonConvert.DeserializeObject<Root>(jsonResponse);
	string message = string.Empty;

	if (!IsApiResponseValid(deserializedRoot, page, out message))
	{
		return new PageResult(message);
	}

	var pattern = $@"\b{Regex.Escape(searchedWord)}\b";
	var shortestQuote = FindShortestQuote(deserializedRoot!.Data, pattern);

	if (shortestQuote is null)
	{
		Console.WriteLine($"No quote found containing '{searchedWord}' on page {page}.");
		return new PageResult($"No quote found containing '{searchedWord}' on page {page}.");
	}

	Console.WriteLine($"Page {page} \"{shortestQuote.QuoteText}\" -- {shortestQuote.QuoteAuthor}");
	return new PageResult(page, shortestQuote.QuoteText, "OK");
}

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

static bool IsApiResponseValid(Root? response, int pageNumber, out string message)
{
	if (response is null)
	{
		message = $"Page {pageNumber}: Received null or invalid JSON response.";
		Console.WriteLine(message);

		return false;
	}

	if (response.Data is null || !response.Data.Any())
	{
		message = $"Page {pageNumber}: No quotes found in response.";
		Console.WriteLine(message);

		return false;
	}

	message = "Api response is valid";
	return true;
}

static Datum FindShortestQuote(IReadOnlyCollection<Datum> responseData, string pattern)
{
	return responseData.Where(data => Regex.IsMatch(data.QuoteText, pattern, RegexOptions.IgnoreCase))
	.OrderBy(match => match.QuoteText.Length).FirstOrDefault();
}