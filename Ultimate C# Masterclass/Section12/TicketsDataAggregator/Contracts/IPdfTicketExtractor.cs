namespace TicketsDataAggregator.Contracts;

public interface IPdfTicketExtractor
{
	IEnumerable<string> ExtractTextFromDirectory(string directoryPath);
}