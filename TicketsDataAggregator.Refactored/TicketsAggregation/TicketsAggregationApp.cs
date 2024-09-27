using System.Text;

internal class TicketsAggregationApp
{
    private string _ticketsFolder;
    private IDocumentsReader _fileReader;
    private IFileWriter _fileWriter;
    private IDataExtractor _dataExtractor;

    public TicketsAggregationApp(IDocumentsReader fileReader, IFileWriter fileWriter, IDataExtractor dataExtractor,string ticketsFolder)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
        _dataExtractor = dataExtractor;
        _ticketsFolder = ticketsFolder;
    }

    public void Run()
    {
        StringBuilder stringBuilder = new StringBuilder();

        var documents = _fileReader.Read(_ticketsFolder);

        foreach(var document in documents)
        {
            var lines = _dataExtractor.ProcessDocument(document);
            stringBuilder.AppendLine(string.Join(Environment.NewLine, lines));
        }

        _fileWriter.Write(stringBuilder.ToString(), "newOutPut.txt");
    }
}
