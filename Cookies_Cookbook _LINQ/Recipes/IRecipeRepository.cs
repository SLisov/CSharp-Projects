using Cookies_Cookbook.Recipes.Ingredients;
namespace Cookies_Cookbook.Recipes;


public interface IRecipeRepository
{
    void WriteRecipeToFile(List<Recipe> recipeToSave, string filePath);
    List<Recipe> ReadRecipesFromFile(string filePath);
}
