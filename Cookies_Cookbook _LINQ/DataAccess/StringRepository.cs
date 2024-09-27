namespace Cookies_Cookbook.DataAccess;

public abstract class StringRepository : IStringRepository
{
    protected static readonly string Separator = Environment.NewLine;

    protected abstract string StringToText(List<string> recipesToWrite);

    protected abstract List<string> TextToStrings(string ingredientsIds);

    public void WriteRecipeToFile(List<string> recipesToWrite, string filePath)
    {
        File.WriteAllText(filePath, StringToText(recipesToWrite));
    }

    public List<string> ReadRecipesFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var ingredientsIds = File.ReadAllText(filePath);
            return TextToStrings(ingredientsIds);
        }
        return new List<string>();
    }
}