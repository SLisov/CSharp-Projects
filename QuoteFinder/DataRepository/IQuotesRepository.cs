internal interface IQuotesRepository
{
    string? GetQuotesFromRepository(string quoteWithWord);
    void SetQuotes(Root root);
}
