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
        var allRecipesToWrite = allRecipes
            .Select(recipe => string.Join(Separator, recipe.Ingredients
                .Select(ingredient => ingredient.Id)))
            .ToList();

        _stringRepository.WriteRecipeToFile(allRecipesToWrite, filePath);
    }

    public List<Recipe> ReadRecipesFromFile(string filePath)
    {
        return _stringRepository.ReadRecipesFromFile(filePath)
            .Select(RecipeFromString)
            .ToList();
    }

    public Recipe RecipeFromString(string recipeFromFile)
    {
        var ingredients = recipeFromFile.Split(Separator)
            .Select(int.Parse)
            .Select(_ingredientsRegister.GetIngredientById)
            .ToList();
        return new Recipe(ingredients);
    }
}
