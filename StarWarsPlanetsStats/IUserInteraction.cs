public interface IUserInteraction
{
    string AskUserForInput();
    void ProccessUserInput(string userInput, IDataRepository dataRepository);
    void ShowMessage(string message);
}