public class ConsoleUserInteraction : IUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string? AskUserForInput()
    {
        return Console.ReadLine();
    }

    public void PrintTable<T>(IEnumerable<T> items)
    {
        TablePrinter.Print(items);
    }
}