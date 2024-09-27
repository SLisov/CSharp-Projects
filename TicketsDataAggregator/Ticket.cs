using System.Globalization;
using System.Text.RegularExpressions;

internal readonly record struct Ticket
{
    public readonly string? Title { get; init; }
    public readonly string? DateTime { get; init; }

    public Ticket(string? title, string? dateTime)
    {
        Title = title;
        DateTime = dateTime;
    }

    public override string ToString()
    {
        return $"{Title,-30} | {DateTime}";
    }
}