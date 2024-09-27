using System.Globalization;

internal class CultureRecognizer : ICultureRecognizer
{
    private readonly Dictionary<string, CultureInfo> _cultureInfo = new()
    {
        ["www.ourCinema.com"] = new CultureInfo("en-US"),
        ["www.ourCinema.fr"] = new CultureInfo("fr-FR"),
        ["www.ourCinema.jp"] = new CultureInfo("ja-JP")
    };

    public CultureInfo Recognize(string input)
    {
        if (_cultureInfo.Keys.Any(k => k.Contains(input)))
        {
            return new CultureInfo("en-US");
        }
        else if (_cultureInfo.Keys.Any(k => k.Contains(input)))
        {
            return new CultureInfo("fr-FR");
        }
        else if (_cultureInfo.Keys.Any(k => k.Contains(input)))
        {
            return new CultureInfo("ja-JP");
        }
        throw new NotImplementedException(
            $"{nameof(input)} - domain culture does not implemented");
    }
}
