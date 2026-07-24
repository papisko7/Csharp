namespace QuoteFinder.Data
{
	public class PageResult
	{
		public int? PageNumber { get; private set; }

		public string? ShortestQuote { get; private set; }

		public string Message { get; private set; }

		public PageResult(string message)
		{
			Message = message;
		}

		public PageResult(int pageNumber, string shortestQuote, string message)
		{
			PageNumber = pageNumber;
			ShortestQuote = shortestQuote;
			Message = message;
		}
	}
}