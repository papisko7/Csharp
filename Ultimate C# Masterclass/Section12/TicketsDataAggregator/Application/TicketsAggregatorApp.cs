using TicketsDataAggregator.Contracts;

namespace TicketsDataAggregator.Application;

public class TicketsAggregatorApp(IPdfTicketExtractor pdfTicketExtractor,
	ICultureManager cultureManager,
	ITicketParser ticketParser,
	IFileWriter fileWriter)
{
	public string? Run(string ticketsDirectoryPath)
	{
		if (string.IsNullOrWhiteSpace(ticketsDirectoryPath)
			|| !Directory.Exists(ticketsDirectoryPath))
		{
			return null;
		}

		var aggregatedTickets = new List<string>();
		var extractedTickets = pdfTicketExtractor
			.ExtractTextFromDirectory(ticketsDirectoryPath);

		foreach (var text in extractedTickets)
		{
			var cultureInfo = cultureManager.GetCulture(text);
			var parsedTickets = ticketParser.ExtractTickets(text, cultureInfo);

			aggregatedTickets.AddRange(parsedTickets
				.Select(ticket => ticket.ToString()));
		}

		var resultFilePath = Path.Combine(ticketsDirectoryPath, "aggregatedTickets.txt");

		fileWriter.WriteLines(resultFilePath, aggregatedTickets);
		return resultFilePath;
	}
}