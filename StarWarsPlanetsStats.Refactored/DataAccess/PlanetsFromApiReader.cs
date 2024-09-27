using StarWarsPlanetsStats.Refactored.ApiDataAccess;
using System.Text.Json;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;

    public PlanetsFromApiReader(IApiDataReader apiDataReader)
    {
        _apiDataReader = apiDataReader;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        var json = await _apiDataReader.Read("https://swapi.dev/", "api/planets");

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }

    public IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}
