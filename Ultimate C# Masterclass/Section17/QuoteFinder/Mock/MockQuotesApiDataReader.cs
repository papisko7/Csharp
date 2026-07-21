using QuoteFinder.Data;
using QuoteFinder.Dto;
using System.Text.Json;

namespace QuoteFinder.Mock;

// This class may be used to get quotes in case Quotes Garden API is down.
// It can be used where QuotesApiDataReader is used as they implement the same interface.
// It generates quotes using 500 most common English words.
public class MockQuotesApiDataReader : IQuotesApiDataReader
{
	private readonly Random _random = new Random();

	public Task<string> ReadAsync(int page, int quotesPerPage)
	{
		var root = new Root(
			StatusCode: 200,
			Message: "Success",
			Pagination: new Pagination(
				CurrentPage: page,
				NextPage: page + 1,
				TotalPages: 100
			),
			TotalQuotes: quotesPerPage,
			Data: GenerateRandomData(quotesPerPage)
		);

		return Task.FromResult(JsonSerializer.Serialize(root));
	}

	private List<Datum> GenerateRandomData(int quotesPerPage)
	{
		return Enumerable.Range(0, quotesPerPage).Select(_ =>
			new Datum(
				Id: Guid.NewGuid().ToString(),
				QuoteText: GenerateRandomQuote(),
				QuoteAuthor: "Unknown",
				QuoteGenre: "general",
				V: 0
			)
		).ToList();
	}

	private string GenerateRandomQuote()
	{
		var length = _random.Next(5, 30);

		return string.Join(" ", Enumerable.Range(0, length)
			.Select(_ => GetRandomWord()));
	}

	private string GetRandomWord()
	{
		var index = _random.Next(0, Words.All.Length);
		return Words.All[index];
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}