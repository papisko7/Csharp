using System.Globalization;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

Console.WriteLine("Enter the directory path containing PDFs:");

var ticketsDirectoryPath = Console.ReadLine();
var pdfFiles = Directory.GetFiles(ticketsDirectoryPath, "*.pdf");
List<string> aggregatedFileData = new List<string>();

foreach (var filePath in pdfFiles)
{
    using PdfDocument document = PdfDocument.Open(filePath);

    foreach (Page page in document.GetPages())
    {
        string text = ContentOrderTextExtractor.GetText(page);

        CultureInfo culture = text.Contains(".com") ? new CultureInfo("en-US") :
            text.Contains(".fr") ? new CultureInfo("fr-Fr") :
            text.Contains(".jp") ? new CultureInfo("jp-JP") :
            CultureInfo.InvariantCulture;
    }
}