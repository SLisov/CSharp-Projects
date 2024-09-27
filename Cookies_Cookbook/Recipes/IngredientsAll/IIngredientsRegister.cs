using Cookies_Cookbook.Recipes.Ingredients;

// IRecipesUserInteractions.PrintExistingRecipes(allRecipes); retunr 0 if no recipes
// IRecipesUserInteractions.PromptToCreateRecipe();
// var Ingredients = _recipeUserInteractions.ReadIngredientsFromUser(); get Ingredients and recipes from user inputs
// print in console recipes which user added  _recipeUserInteractions.ShowMessage(recipes.ToString());

namespace Cookies_Cookbook.Recipes.IngredientsAll;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> AllIngredients { get; }

    Ingredient GetIngredientById(int id);
    void ShowAllIngredients();
}
