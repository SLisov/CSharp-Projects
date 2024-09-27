internal class App
{
    private IQuotesRepository _quotesRepository;
    private IGetQuotesFrom _getQuotesFromApi;
    private IUserInteraction _consoleUserInteraction;
    public App(IQuotesRepository quotesRepository,
        IGetQuotesFrom getQuotesFromApi,
        IUserInteraction consoleUserInteraction)
    {
        _quotesRepository = quotesRepository;
        _getQuotesFromApi = getQuotesFromApi;
        _consoleUserInteraction = consoleUserInteraction;
    }
    public async Task Run()
    {
        const string stringTypeInput = "string";
        const string IntTypeInput = "int";

        var requiredWord = _consoleUserInteraction
            .ReadUserInput("What word are you looking for ?",stringTypeInput);

        var quotesAmount = int.Parse(_consoleUserInteraction
            .ReadUserInput("Set quoates limit to be loaded",IntTypeInput));

        _consoleUserInteraction.ShowMessage("Fetching data...");

        var quoutesCollection = await _getQuotesFromApi
            .GetQuotesAsync(quotesAmount);

        _consoleUserInteraction.ShowMessage("Data is ready.");

        _quotesRepository
            .SetQuotes(quoutesCollection);

        _consoleUserInteraction.ShowQuotes(requiredWord);
    }
}
