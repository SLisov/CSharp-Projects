using Cookies_Cookbook.Recipes.Ingredients;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

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
        var result = AllIngredients.Select(i =>
        {
            Console.WriteLine(i);
            return i;
        }).ToList();
    }

    public Ingredient GetIngredientById(int id)
    {
        //return AllIngredients.FirstOrDefault(item => item.Id == id);

        var allIngredientsWithGivenId = AllIngredients.Where(ingredient => ingredient.Id == id);

        if (allIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException($"More than one ingredients have ID equal to {id}");
        }

        if (AllIngredients.Select(ingredient => ingredient.Id).Distinct().Count() != AllIngredients.Count())
        {
            throw new InvalidOperationException($"Some ingredients have duplicated IDs.");
        }

        return allIngredientsWithGivenId.FirstOrDefault(ingrediend => ingrediend.Id == id);
    }
}
