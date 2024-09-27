namespace GameDataParser.UserInteraction
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        string PromptToEnterFileName();
        void ShowErrorMessage(string message);
    }

}
