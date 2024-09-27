namespace GameDataParser.UserInteraction
{
    public class ConsoleUserInteraction : IUserInteraction
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ShowMessage(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string PromptToEnterFileName()
        {
            ShowMessage("Enter the name of the file you want to read:");
            string fileNameToEnter = Console.ReadLine();

            if (fileNameToEnter is null)
            {
                ShowMessage("File name cannot be null.");
                return PromptToEnterFileName();
            }
            else if (fileNameToEnter == string.Empty)
            {
                ShowMessage("File name cannot be empty.");
                return PromptToEnterFileName();
            }
            else if (!File.Exists(fileNameToEnter))
            {
                ShowMessage("File not found.");
                return PromptToEnterFileName();
            }
            return fileNameToEnter;
        }
    }

}
