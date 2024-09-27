using Cookies_Cookbook.Recipes;
using System.Security.Cryptography.X509Certificates;
using static Cookies_Cookbook.App.ApplicationMain;

namespace Cookies_Cookbook.App;

// SINGLE RESPONSIBILITY PRINCIPLE
// REUSE THE SAME CODE WITH THE SAME FUNCTIONS
// STEP BY STEP APPROACH
// SAVE FILES TO JSON & TXT FILE

//Interdependence !!!
//Dependency Inversion !
//Dependency Injection !

public partial class ApplicationMain
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipesUserInteractions _recipeUserInteractions;

    public ApplicationMain(IRecipeRepository recipeRepository, IRecipesUserInteractions userInteractions)
    {
        _recipeRepository = recipeRepository;
        _recipeUserInteractions = userInteractions;
    }

    public void AppRun(string filePath)
    {
        List<Recipe> AllRecipes = _recipeRepository.ReadRecipesFromFile(filePath);

        _recipeUserInteractions.PrintExistingRecipes(AllRecipes);
        _recipeUserInteractions.PromptToCreateRecipe();
        var ingredients = _recipeUserInteractions.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var newRecipe = new Recipe(ingredients);
            AllRecipes.Add(newRecipe);

            _recipeRepository.WriteRecipeToFile(AllRecipes, filePath);

            _recipeUserInteractions.ShowMessage("Recipe added:\n");
            _recipeUserInteractions.ShowMessage(newRecipe.ToString());
        }
        else
        {
            _recipeUserInteractions.ShowMessage("\nNo Ingredients have been selected. Recipe will not be saved.");
        }

        _recipeUserInteractions.Exit();
    }
}
