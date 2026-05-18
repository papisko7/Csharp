using TicketsDataAggregator;

Console.WriteLine("Enter the directory path containing PDFs:");
var ticketsDirectoryPath = Console.ReadLine();

if (string.IsNullOrWhiteSpace(ticketsDirectoryPath)
	|| !Directory.Exists(ticketsDirectoryPath))
{
	Console.WriteLine("Invalid directory provided");
	return;
}

var aggregatedTickets = new List<string>();

foreach (var text in PdfTicketExtractor.ExtractTextFromDirectory(ticketsDirectoryPath))
{
	var cultureInfo = CultureManager.GetCulture(text);
	var parsedTickets = TicketParser.ExtractTickets(text, cultureInfo);

	aggregatedTickets.AddRange(parsedTickets
		.Select(ticket => ticket.ToString()));
}

var resultFilePath = Path.Combine(ticketsDirectoryPath, "aggregatedTickets.txt");
File.WriteAllLines(resultFilePath, aggregatedTickets);

Console.WriteLine($"Result saved to {resultFilePath}");
Console.WriteLine("Press any key to close");
Console.ReadKey();