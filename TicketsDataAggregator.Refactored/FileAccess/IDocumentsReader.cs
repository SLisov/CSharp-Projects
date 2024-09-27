internal interface IDocumentsReader
{
    IEnumerable<string> Read(string path);
}
