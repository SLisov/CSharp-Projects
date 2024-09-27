using Cookies_Cookbook.Recipes;
using Cookies_Cookbook.Recipes.Ingredients;
using Cookies_Cookbook.Recipes.IngredientsAll;

namespace Cookies_Cookbook.App;

public class RecipesUserInteractions : IRecipesUserInteractions
{
    private readonly IIngredientsRegister _ingredientRegister;

    public RecipesUserInteractions(IIngredientsRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if (recipes.Any())
        {
            Console.WriteLine("Existing recipes are:");

            var allRecipesAsStrings = recipes
                .Select((recipe,index) =>
$@"*****{index + 1}*****
{recipe}");
                Console.WriteLine(string.Join(Environment.NewLine, allRecipesAsStrings));
                Console.WriteLine();
        }
    }

    public void PromptToCreateRecipe()
    {
        ShowMessage("\nCreate a new cookie Ingredients! Available Ingredients are:\n");

        _ingredientRegister.ShowAllIngredients();
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool keepPrompt = true;

        var result = new List<Ingredient>();

        while (keepPrompt)
        {
            ShowMessage("\nAdd an ingredient by its ID or type anything else if finished.");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                var selectedIngredient = _ingredientRegister.GetIngredientById(input);

                if (selectedIngredient is not null)
                {
                    result.Add(selectedIngredient);
                }
            }
            else
            {
                keepPrompt = false;
            }
        }
        return result;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("\nPress any key to exit.");
        Console.Read();
    }
}
