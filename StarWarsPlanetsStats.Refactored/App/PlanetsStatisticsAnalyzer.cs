public class PlanetsStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteraction _planetsStatsUserInteraction;

    public PlanetsStatisticsAnalyzer(IPlanetsStatsUserInteraction planetsStatsUserInteraction)
    {
        _planetsStatsUserInteraction = planetsStatsUserInteraction;
    }
    private readonly Dictionary<string, Func<Planet, long?>> _propertyNamesToSelectorsMapping =
        new()
        {
            ["population"] = planet => planet.Population,
            ["diameter"] = planet => planet.Diameter,
            ["surfacewater"] = planet => planet.SurfaceWater
        };

    public void Analyze(IEnumerable<Planet> planets)
    {
        var userChoice = _planetsStatsUserInteraction.ChooseStaticticsToBeShown(_propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null || !_propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            _planetsStatsUserInteraction.ShowMessage("Invalid choice.");
        }
        else
        {
            ShowStatistics(planets,userChoice,_propertyNamesToSelectorsMapping[userChoice]);
        }
    }

    private void ShowStatistics(IEnumerable<Planet> planets, string propertyName, Func<Planet, long?> propertySelector)
    {
        ShowStatistics("Max", planets.MaxBy(propertySelector), propertyName, propertySelector);

        ShowStatistics("Min", planets.MinBy(propertySelector), propertyName, propertySelector);
    }

    private void ShowStatistics(string descriptor, Planet planet, string propertyName, Func<Planet, long?> propertySelector)
    {
        _planetsStatsUserInteraction.ShowMessage($"{descriptor} {propertyName} is: {propertySelector(planet)} (planet: {planet.Name})");
    }
}
