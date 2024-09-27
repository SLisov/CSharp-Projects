using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

internal class DocumentsReader : IDocumentsReader
{
    public IEnumerable<string> Read(string path)
    {
        string[] pdfFiles = Directory.GetFiles(path, "*.pdf");

        if (pdfFiles is null || pdfFiles.Length == 0)
        {
            throw new ArgumentNullException("path does not contains PDF files");
        }

        foreach (var pdfFile in pdfFiles)
        {
            using (PdfDocument document = PdfDocument.Open(pdfFile))
            {
                Page page = document.GetPage(1);
                yield return page.Text;
            }
        }
    }
}
