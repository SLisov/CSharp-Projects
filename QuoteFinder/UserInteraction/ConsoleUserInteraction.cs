internal class ConsoleUserInteraction : IUserInteraction
{
    private readonly IQuotesRepository _quotesRepository1;

    public ConsoleUserInteraction(IQuotesRepository quotesRepository1)
    {
        _quotesRepository1 = quotesRepository1;
    }

    public void ShowQuotes(string requiredWord)
    {
        var quotesToShow = _quotesRepository1
            .GetQuotesFromRepository(requiredWord);

        if (!string.IsNullOrEmpty(quotesToShow))
        {
            ShowMessage(quotesToShow);
            return;
        }

        ShowMessage($"No quotes are found with word '{requiredWord}'." +
                $"Try increase quotes limit");
    }

    public void ShowMessage(string message) => Console.WriteLine(message);
    public string ReadUserInput(string message,string inputType)
    {
        string input;

        do
        {
            ShowMessage(message);
            input = Console.ReadLine()!;

        } while (!ValidateInput(input, inputType));

        return input!;
    }

    private static bool ValidateInput(string? input, string inputType)
    {
        if (inputType.Equals("int"))
        {
            return
            !string.IsNullOrEmpty(input)
            && input.All(chars =>
            char.IsDigit(chars));
        }
        else if (inputType.Equals("string"))
        {
            return
            !string.IsNullOrEmpty(input)
            && input.All(chars =>
            char.IsLetter(chars));
        }
        throw new NotImplementedException("Argument type not implemented");
    }

}
