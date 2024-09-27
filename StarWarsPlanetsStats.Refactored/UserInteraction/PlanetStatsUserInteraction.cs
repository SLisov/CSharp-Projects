public class PlanetStatsUserInteraction : IPlanetsStatsUserInteraction
{
    private readonly IUserInteraction _userInteraction;

    public PlanetStatsUserInteraction(IUserInteraction userInteractor)
    {
        _userInteraction = userInteractor;
    }

    public void ShowMessage(string message)
    {
        _userInteraction.ShowMessage($"{message}");
    }

    public void Show(IEnumerable<Planet> planets)
    {
        _userInteraction.PrintTable(planets);
    }

    public string? ChooseStaticticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteraction.ShowMessage(Environment.NewLine + "The statistics of which property would you like to see?");
        _userInteraction.ShowMessage(string.Join(Environment.NewLine,propertiesThatCanBeChosen));

        return _userInteraction.AskUserForInput();
    }
}