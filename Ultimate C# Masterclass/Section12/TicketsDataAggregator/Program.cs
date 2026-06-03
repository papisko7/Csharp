using TicketsDataAggregator.Application;
using TicketsDataAggregator.Contracts;
using TicketsDataAggregator.Globalization;
using TicketsDataAggregator.IO;
using TicketsDataAggregator.Services;
using TicketsDataAggregator.UI;

ICultureManager cultureManager = new CultureManager();
IPdfTicketExtractor pdfTicketExtractor = new PdfTicketExtractor();
ITicketParser ticketParser = new TicketParser();
IFileWriter fileWriter = new FileWriter();
IUserInterface ui = new ConsoleUserInterface();

var app = new TicketsAggregatorApp(pdfTicketExtractor,
	cultureManager,
	ticketParser,
	fileWriter);

var ticketsDirectoryPath = ui.GetInput("Enter the directory path containing PDFs" +
									   @"(ex. C:\Users\admin\Downloads):");
if (ticketsDirectoryPath != null)
{
	var resultFilePath = app.Run(ticketsDirectoryPath);
	ui.ShowMessage($"Result saved to {resultFilePath}");
}

ui.WaitForKey("Press any key to close");