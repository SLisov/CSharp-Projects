using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Channels;
using System.Xml;
using Cookies_Cookbook.App;
using Cookies_Cookbook.DataAccess;
using Cookies_Cookbook.FileAccess;
using Cookies_Cookbook.Recipes;
using Cookies_Cookbook.Recipes.IngredientsAll;

namespace Cookies_Cookbook;

internal class Program
{
    static void Main(string[] args)
    {
        const FileFormat Format = FileFormat.txt;

        IStringRepository stringRepository = Format == FileFormat.json ? new StringJsonRepository() : new StringTextualRepository();

        const string FileName = "recipe";
        var fileMetadata = new FileMetadata(FileName, Format);

        var ingredientsRegister = new IngredientsRegister();

        var applicationMain = new ApplicationMain(new RecipeRepository(stringRepository, ingredientsRegister), new RecipesUserInteractions(ingredientsRegister));
        applicationMain.AppRun(fileMetadata.ToPath());
        
    }
}
