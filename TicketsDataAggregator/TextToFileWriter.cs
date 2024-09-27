internal class TextToFileWriter : IFileWriter
{
    public void Write(IEnumerable<string> data)
    {
        File.WriteAllLines("output.txt", data);
    }
}
