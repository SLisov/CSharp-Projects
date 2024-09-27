namespace Cookies_Cookbook.DataAccess;

public interface IStringRepository
{
    List<string> ReadRecipesFromFile(string filePath);
    void WriteRecipeToFile(List<string> recipeToSave, string filePath);
}