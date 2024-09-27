using Cookies_Cookbook.Recipes.Ingredients;

// IRecipesUserInteractions.PrintExistingRecipes(allRecipes); retunr 0 if no recipes
// IRecipesUserInteractions.PromptToCreateRecipe();
// var Ingredients = _recipeUserInteractions.ReadIngredientsFromUser(); get Ingredients and recipes from user inputs
// print in console recipes which user added  _recipeUserInteractions.ShowMessage(recipes.ToString());

namespace Cookies_Cookbook.Recipes.IngredientsAll;


public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> AllIngredients { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamon(),
        new Cinnamon(),
        new Cocoapowder()
    };

    public void ShowAllIngredients()
    {
        foreach (var item in AllIngredients)
        {
            Console.WriteLine(item);
        }
    }

    public Ingredient GetIngredientById(int id)
    {
        foreach (var ingredient in AllIngredients)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }
        return null;
    }
}
