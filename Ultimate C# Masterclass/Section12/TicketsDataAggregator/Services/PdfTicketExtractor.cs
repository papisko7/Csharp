using TicketsDataAggregator.Contracts;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace TicketsDataAggregator.Services;

public class PdfTicketExtractor : IPdfTicketExtractor
{
	public IEnumerable<string> ExtractTextFromDirectory(string directoryPath)
	{
		if (!Directory.Exists(directoryPath))
		{
			yield break;
		}

		var pdfFiles = Directory.GetFiles(directoryPath, "*.pdf");
		foreach (var filePath in pdfFiles)
		{
			using var document = PdfDocument.Open(filePath);
			foreach (var page in document.GetPages())
			{
				yield return ContentOrderTextExtractor.GetText(page);
			}
		}
	}
}