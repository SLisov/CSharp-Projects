internal interface IDataExtractor
{
    IEnumerable<string> ProcessDocument(string page);
}
