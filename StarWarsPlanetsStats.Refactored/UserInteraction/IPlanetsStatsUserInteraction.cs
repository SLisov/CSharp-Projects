public interface IPlanetsStatsUserInteraction
{
    string? ChooseStaticticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen);
    void Show(IEnumerable<Planet> planets);
    void ShowMessage(string message);
}