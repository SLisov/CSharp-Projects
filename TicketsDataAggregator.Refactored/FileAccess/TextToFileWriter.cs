internal class TextToFileWriter : IFileWriter
{
    public void Write(string content, string path)
    {
        File.WriteAllText(path,content);
        Console.WriteLine("Results saved to " + path);
    }
}
