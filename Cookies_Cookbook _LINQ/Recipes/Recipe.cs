using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookies_Cookbook.Recipes.Ingredients;

namespace Cookies_Cookbook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, Ingredients.Select(ingredient => $"{ingredient.Name}. {ingredient.PreparationInstructions}"));
    }
}
