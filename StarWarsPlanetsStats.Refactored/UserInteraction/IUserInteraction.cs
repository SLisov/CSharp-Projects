public interface IUserInteraction
{
    string? AskUserForInput();
    void ShowMessage(string message);
    void PrintTable<T>(IEnumerable<T> items);
}
