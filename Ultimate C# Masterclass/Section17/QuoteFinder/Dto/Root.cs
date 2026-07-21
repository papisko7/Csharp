using Newtonsoft.Json;

namespace QuoteFinder.Dto;

public record Root(
	[property: JsonProperty("statusCode")]
	int? StatusCode,

	[property: JsonProperty("message")]
	string Message,

	[property: JsonProperty("pagination")]
	Pagination Pagination,

	[property: JsonProperty("totalQuotes")]
	int? TotalQuotes,

	[property: JsonProperty("data")]
	IReadOnlyList<Datum> Data
);