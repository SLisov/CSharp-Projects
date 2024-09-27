public static class StringExtensions
{
    public static long? ToIntOrNull(this string? input)
    {
        return long.TryParse(input, out long resultParsed) ? resultParsed : null;
    }
}