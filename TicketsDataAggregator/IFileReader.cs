internal interface IFileReader
{
    IEnumerable<string?> Read(string path);
}
