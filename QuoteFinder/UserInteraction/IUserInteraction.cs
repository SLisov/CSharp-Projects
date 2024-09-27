internal interface IUserInteraction
{
    string ReadUserInput(string message,string inputType);
    void ShowMessage(string message);
    void ShowQuotes(string requiredWord);
}
