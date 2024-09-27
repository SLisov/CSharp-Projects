using UglyToad.PdfPig;

internal class PdfReader : IFileReader
{
    private List<string> _data = new List<string>();

    public IEnumerable<string> Read(string path)
    {
        string[] pdfFiles = Directory
            .GetFiles(path, "*.pdf");

        if (pdfFiles is null || pdfFiles.Length == 0)
        {
            throw new ArgumentNullException(
                "path does not contains PDF files");
        }

        foreach (var pdfFile in pdfFiles)
        {
            using (PdfDocument document = PdfDocument.Open(pdfFile))
            {
                foreach (var page in document.GetPages())
                {
                    _data.Add(page.Text);
                }
            }
        }
        return _data;
    }
}
