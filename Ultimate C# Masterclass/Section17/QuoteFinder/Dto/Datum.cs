using Newtonsoft.Json;

namespace QuoteFinder.Dto;

public record Datum(
	[property: JsonProperty("_id")]
	string Id,

	[property: JsonProperty("quoteText")]
	string QuoteText,

	[property: JsonProperty("quoteAuthor")]
	string QuoteAuthor,

	[property: JsonProperty("quoteGenre")]
	string QuoteGenre,

	[property: JsonProperty("__v")]
	int? V
);
