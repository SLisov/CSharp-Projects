namespace GameDataParser.DataAccess
{
    public class LocalFileReader : IFileReader
    {
        public string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }

}
