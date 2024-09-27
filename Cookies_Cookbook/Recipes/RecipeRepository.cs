using Cookies_Cookbook.DataAccess;
using Cookies_Cookbook.Recipes.Ingredients;
using Cookies_Cookbook.Recipes.IngredientsAll;
using System.Text.Json;
using static Cookies_Cookbook.App.ApplicationMain;

namespace Cookies_Cookbook.Recipes;

public class RecipeRepository : IRecipeRepository
{
    private readonly IStringRepository _stringRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipeRepository(IStringRepository stringRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringRepository = stringRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public void WriteRecipeToFile(List<Recipe> allRecipes, string filePath)
    {
        List<string> allRecipesToWrite = new List<string>();

        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            allRecipesToWrite.Add(string.Join(Separator, allIds));
        }
        _stringRepository.WriteRecipeToFile(allRecipesToWrite, filePath);

    }

    public List<Recipe> ReadRecipesFromFile(string filePath)
    {
        List<string> recipesFromFile = _stringRepository.ReadRecipesFromFile(filePath);
        var allRecipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = recipeFromString(recipeFromFile);
            allRecipes.Add(recipe);
        }

        return allRecipes;
    }

    public Recipe recipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            ingredients.Add(_ingredientsRegister.GetIngredientById(id));
        }

        return new Recipe(ingredients);
    }
}
