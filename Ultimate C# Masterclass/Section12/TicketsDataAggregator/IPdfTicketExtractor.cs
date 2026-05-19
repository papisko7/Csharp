namespace TicketsDataAggregator;

public interface IPdfTicketExtractor
{
	IEnumerable<string> ExtractTextFromDirectory(string directoryPath);
}