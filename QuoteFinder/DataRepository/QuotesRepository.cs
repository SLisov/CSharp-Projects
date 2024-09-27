internal class QuotesRepository : IQuotesRepository
{
    private Root? _root;

    public void SetQuotes(Root root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(
                "No quotes are found in API", nameof(root));
        }
        _root = root;
    }

    public string? GetQuotesFromRepository(string requiredWord)
    {
        IOrderedEnumerable<Quote> resultQuotes =
            SortQuotesWithRequiredWord(requiredWord);

        if (resultQuotes.Count() != 0)
        {
            return string
                .Join(Environment.NewLine, resultQuotes);
        }

        return null;
    }

    private IOrderedEnumerable<Quote> SortQuotesWithRequiredWord(string requiredWord)
    {
        return _root.quotes
            .Where(quote => quote.quote
            .Split(new[] { ' ', '.', ',', '!', '?', ';', ':' },
            StringSplitOptions.RemoveEmptyEntries)
            .Any(word => string
            .Equals(word, requiredWord,
            StringComparison.OrdinalIgnoreCase)))
            .OrderBy(quote => quote.quote.Length);
    }
}
