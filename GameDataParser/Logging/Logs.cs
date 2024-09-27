namespace GameDataParser.Logging
{
    public class Logs
    {
        private readonly string _fileLogsName;

        public Logs(string fileLogsName)
        {
            _fileLogsName = fileLogsName;
        }

        public void Log(Exception exception)
        {
            string logToWrite =
            $@"[{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt")}]
            Exception message: {exception.Message}
            Stack trace: {exception.StackTrace}

            ";
            File.AppendAllText(_fileLogsName, logToWrite);
        }
    }

}
