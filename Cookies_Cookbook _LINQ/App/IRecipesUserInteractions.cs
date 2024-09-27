using Cookies_Cookbook.Recipes;
using Cookies_Cookbook.Recipes.Ingredients;
namespace Cookies_Cookbook.App;

public interface IRecipesUserInteractions
{
    void PromptToCreateRecipe();
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    IEnumerable<Ingredient> ReadIngredientsFromUser();
    void ShowMessage(string message);
    void Exit();
}
