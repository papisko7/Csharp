using Newtonsoft.Json;

namespace QuoteFinder.Dto;

public record Pagination(
	[property: JsonProperty("currentPage")]
	int? CurrentPage,

	[property: JsonProperty("nextPage")]
	int? NextPage,

	[property: JsonProperty("totalPages")]
	int? TotalPages
);
