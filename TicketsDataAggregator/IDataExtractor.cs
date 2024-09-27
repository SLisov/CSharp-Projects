internal interface IDataExtractor
{
    IEnumerable<string>? ToTicket(IEnumerable<string> text);
}
