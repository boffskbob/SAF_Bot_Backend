using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

public static string ExtractTextFromPdf(string pdfPath)
{
    using var pdfReader = new PdfReader(pdfPath);
    using var pdfDoc = new PdfDocument(pdfReader);
    var text = new StringBuilder();

    for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
    {
        var strategy = new SimpleTextExtractionStrategy();
        string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
        text.AppendLine(pageText);
    }

    return text.ToString();
}
