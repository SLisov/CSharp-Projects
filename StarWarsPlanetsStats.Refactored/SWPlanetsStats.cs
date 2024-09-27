using StarWarsPlanetsStats.Refactored.ApiDataAccess;

try
{
    var apiDataReader = new PlanetsFromApiReader(new ApiDataReader());
    var ConsoleuserInteraction = new ConsoleUserInteraction();
    var planetsStatsUserInteraction = new PlanetStatsUserInteraction(ConsoleuserInteraction);
    var planetsStatisticsAnalyzer = new PlanetsStatisticsAnalyzer(planetsStatsUserInteraction);
    var application = new App(apiDataReader, ConsoleuserInteraction, planetsStatisticsAnalyzer, planetsStatsUserInteraction);

    await application.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. " +
        "Exception message: " + ex.Message);
}

Console.ReadLine();
