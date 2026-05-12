using System.Globalization;
using System.Text.RegularExpressions;
using TicketsDataAggregator;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

Console.WriteLine("Enter the directory path containing PDFs:");

var ticketsDirectoryPath = Console.ReadLine();
var pdfFiles = Directory.GetFiles(ticketsDirectoryPath, "*.pdf");
List<string> aggregatedTickets = new List<string>();
string ticketPattern = @"Title:\s*(.*?)\s*Date:\s*(.*?)\s*Time:\s*(.*?)(?=\s*Title:|\s*Visit us:|$)";

foreach (var filePath in pdfFiles)
{
	using PdfDocument document = PdfDocument.Open(filePath);

	foreach (Page page in document.GetPages())
	{
		string text = ContentOrderTextExtractor.GetText(page);
		var culture = CultureManager.getCulture(text);

		MatchCollection matches = Regex.Matches(text,
			ticketPattern,
			RegexOptions.Singleline);

		foreach (Match match in matches)
		{
			var movieNameStr = match.Groups[1].Value.Replace("\n", "").Replace("\r", "").Trim();
			var dateStr = match.Groups[2].Value.Trim();
			var timeStr = match.Groups[3].Value.Trim();

			if (DateTime.TryParse(dateStr, culture, DateTimeStyles.None, out DateTime parsedDate) &&
				DateTime.TryParse(timeStr, culture, DateTimeStyles.None, out DateTime parsedTime))
			{
				aggregatedTickets.Add(new TicketData
				{
					MovieName = movieNameStr,
					Date = parsedDate,
					Time = parsedTime
				}
				.ToString());
			}
		}
	}
}

string resultFilePath = Path.Combine(ticketsDirectoryPath, "aggregatedTickets.txt");
File.WriteAllLines(resultFilePath, aggregatedTickets);

Console.WriteLine($"Result saved to {resultFilePath}");
Console.WriteLine("Press any key to close");
Console.ReadKey();