//var passwordGenerator = new PasswordGeneratorApp(new RandomNumber());

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(passwordGenerator.Generate(5, 10, false));
//}
//Console.ReadKey();

namespace PasswordGenerator;

public interface IRandomNumber
{
    public int Random(int min,int max);
    public int Random(int max);
}
public class RandomNumber : IRandomNumber
{
    public int Random(int min, int max)
    {
        return new Random().Next(min, max);
    }

    public int Random(int max)
    {
        return new Random().Next(max);
    }
}
public class PasswordGeneratorApp
{
    private readonly IRandomNumber _random;

    public PasswordGeneratorApp(
        IRandomNumber random)
    {
        _random = random;
    }

    public string Generate(
        int rangeMin,
        int rangeMax,
        bool useSpecialCharacters)
    {
        ValidateRange(rangeMin, rangeMax);

        int passwordLength = GeneratePasswordLength(
            rangeMin, rangeMax);

        var charsToBeIncluded = useSpecialCharacters ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return GenerateRandomString(passwordLength, charsToBeIncluded);
    }

    private void ValidateRange(int rangeMin, int rangeMax)
    {
        if (rangeMin < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(rangeMin)} must be greater than 0");
        }
        if (rangeMax < rangeMin)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(rangeMin)} must be smaller than {nameof(rangeMax)}");
        }
    }
    private int GeneratePasswordLength(int rangeMin, int rangeMax)
    {
        return
            _random.Random(
                    rangeMin, rangeMax + 1);
    }
    private string GenerateRandomString(int length, string charsToBeIncluded)
    {
        var passwordCharacters = Enumerable
                    .Repeat(charsToBeIncluded, length)
                    .Select(randomChars => randomChars[_random.Random(randomChars.Length)])
                    .ToArray();
        return
            new string(passwordCharacters);
    }
}