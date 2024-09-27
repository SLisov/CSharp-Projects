namespace Cookies_Cookbook.DataAccess;

public class StringTextualRepository : StringRepository
{

    protected override string StringToText(List<string> recipesToWrite)
    {
        return string.Join(Separator, recipesToWrite);
    }

    protected override List<string> TextToStrings(string ingredientsIds)
    {
        return ingredientsIds.Split(Separator).ToList();
    }
}