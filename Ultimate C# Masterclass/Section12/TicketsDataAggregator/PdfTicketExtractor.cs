using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace TicketsDataAggregator
{
	public static class PdfTicketExtractor
	{
		public static IEnumerable<string> ExtractTextFromDirectory(string directoryPath)
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
}