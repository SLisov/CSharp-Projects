using System.Text.Json;

namespace Cookies_Cookbook.DataAccess;

public class StringJsonRepository : StringRepository
{
    protected override string StringToText(List<string> recipesToWrite)
    {
        return JsonSerializer.Serialize(recipesToWrite);
    }

    protected override List<string> TextToStrings(string ingredientsIds)
    {
        return JsonSerializer.Deserialize<List<string>>(ingredientsIds);
    }
}