using System.Globalization;

internal interface ICultureRecognizer
{
    CultureInfo Recognize(string input);
}
