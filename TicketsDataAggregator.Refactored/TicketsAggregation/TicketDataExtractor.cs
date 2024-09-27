using System.Globalization;

internal class TicketDataExtractor : IDataExtractor
{
    private readonly Dictionary<string, CultureInfo> _cultureInfo = new()
    {
        [".com"] = new CultureInfo("en-US"),
        [".fr"] = new CultureInfo("fr-FR"),
        [".jp"] = new CultureInfo("ja-JP")
    };

    public IEnumerable<string> ProcessDocument(string document)
    {
        var split = document.Split(new[] { "Title:", "Date:", "Time:", "Visit us:" }, StringSplitOptions.None);

        var domain = split.Last().ExtractDomain();
        var ticketCulture = _cultureInfo[domain];

        for (int i = 1; i < split.Length - 3; i += 3)
        {
           yield return BuildTicket(split, ticketCulture, i);
        }
    }

    private string BuildTicket(string[] split, CultureInfo ticketCulture, int i)
    {
        var title = split[i];
        var dateAsString = split[i + 1];
        var timeAsString = split[i + 2];

        var date = DateOnly.Parse(dateAsString, ticketCulture);
        var time = TimeOnly.Parse(timeAsString, ticketCulture);

        var dateAsStringInvariant = date.ToString(CultureInfo.InvariantCulture);
        var timeAsStringInvariant = time.ToString(CultureInfo.InvariantCulture);

        return $"{title,-40}| {dateAsStringInvariant} | {timeAsStringInvariant}";
    }
}
