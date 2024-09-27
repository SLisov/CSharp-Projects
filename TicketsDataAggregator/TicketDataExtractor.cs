using System.Globalization;
using System.Text.RegularExpressions;

internal class TicketDataExtractor : IDataExtractor
{
    private ICultureRecognizer _cultureRecognizer;

    private string? title;
    private string? date;
    private string? time;
    private string? cultureOfTicket;
    private string? formattedDateTime;
    private DateTime parsedDateTime;

    public TicketDataExtractor(ICultureRecognizer cultureRecognizer)
    {
        _cultureRecognizer = cultureRecognizer;
    }

    public IEnumerable<string> ToTicket(
        IEnumerable<string> ticketsTextCollection)
    {
        List<string> result = new List<string>();

        string pattern =
            @"Title:\s*(.+?)\s*Date:\s*(\d{1,2}/\d{1,2}/\d{4}|\d{4}/\d{1,2}/\d{1,2})\s*Time:\s*([\d:]+(?:\s*[APM]{2})?)\s*(?:Visit us:\s*(\S+))?";

        foreach (var ticket in ticketsTextCollection)
        {
            MatchCollection matches = Regex.Matches(ticket, pattern);

            for (int i = matches.Count - 1; i >= 0; i--)
            {
                // Extract Ticket data (title,date,time)
                title = matches[i].Groups[1].Value;
                date = matches[i].Groups[2].Value;
                time = matches[i].Groups[3].Value;
                cultureOfTicket = matches[i].Groups[4].Value;

                // Parse date-time due to country(culture) of ticket
                parsedDateTime = DateTime.Parse($"{date} {time}",
                    _cultureRecognizer.Recognize(cultureOfTicket));

                // Converting Date and Time to Universal Format
                formattedDateTime = parsedDateTime
                    .ToString("MM/dd/yyyy | H:mm", CultureInfo.InvariantCulture);

                // Adding new ticket to collection of tickets
                result.Add(new Ticket(title,
                    formattedDateTime).ToString());
            }
        }
        return result;
    }
}
