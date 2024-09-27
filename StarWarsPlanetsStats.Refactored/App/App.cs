public class App
{
    private IPlanetsStatsUserInteraction _planetsStatsuserInteraction;
    private IPlanetsReader _planetsReader;
    private IUserInteraction _userInteraction;
    private IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;

    public App(IPlanetsReader planetsReader, IUserInteraction userInteraction, IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer, IPlanetsStatsUserInteraction planetsStatsuserInteraction)
    {
        _planetsReader = planetsReader;
        _userInteraction = userInteraction;
        _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
        _planetsStatsuserInteraction = planetsStatsuserInteraction;
    }

    public async Task Run()
    {
        var planetsCollection = await _planetsReader.Read();

        _planetsStatsuserInteraction.Show(planetsCollection);
        _planetsStatisticsAnalyzer.Analyze(planetsCollection);
        _userInteraction.ShowMessage("Press any key to close.");
    }
}
