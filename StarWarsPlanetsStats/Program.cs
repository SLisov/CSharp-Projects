using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

//Main work region
#region Main

var baseAddress = "https://swapi.dev/api/";
var requestUri = "planets";

var apiDataReader = new ApiDataReader();
var printData = new PrintData();
var textConverter = new TextConverter();
var userInteraction = new UserInteraction();
var dataRepository = new DataRepository(apiDataReader.Read(baseAddress, requestUri));
var application = new App(baseAddress, requestUri, apiDataReader, printData, userInteraction, dataRepository);
application.Run();

#endregion

Console.ReadLine();

public class App
{
    private IApiDataReader _apiDataReader;
    private IPrintData _printData;
    private IUserInteraction _userInteraction;
    private IDataRepository _dataRepository;

    private string _baseAddress { get; init; }
    private string _requestUri { get; init; }

    public App(string baseAddress, string requestUri, IApiDataReader apiDataReader, IPrintData printData, IUserInteraction userInteraction, IDataRepository dataRepository)
    {
        _baseAddress = baseAddress;
        _requestUri = requestUri;
        _apiDataReader = apiDataReader;
        _printData = printData;
        _userInteraction = userInteraction;
        _dataRepository = dataRepository;
    }

    public void Run()
    {
        Root root = TextConverter.JsonToString<Root>(_dataRepository.GetData());
        foreach (var planet in root.results)
        {
            _dataRepository.AddKeyAndValueToPlanetsDiameter(planet.Name, planet.Diameter);
            _dataRepository.AddKeyAndValueToPlanetsSurfaceWater(planet.Name, planet.SurfaceWater);
            _dataRepository.AddKeyAndValueToPlanetsPopulation(planet.Name, planet.Population);
        }
        _printData.Print(root.results);

        _userInteraction.ShowMessage("");
        _userInteraction.ShowMessage("The statistics of which property would you like to see?");
        _userInteraction.ShowMessage("Population");
        _userInteraction.ShowMessage("Diameter");
        _userInteraction.ShowMessage("SurfaceWater");
        _userInteraction.ShowMessage("");

        _userInteraction.ProccessUserInput(_userInteraction.AskUserForInput(), _dataRepository);
    }
}

public class TextConverter
{
    public static T JsonToString<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();

    }
}

public interface IPrintData
{
    void Print<T>(IEnumerable<T> collection);
}

public class PrintData : IPrintData
{
    public void Print<T>(IEnumerable<T> collection)
    {
        const string lineTable = "---------------";
        const string wallTable = "|";

        var type = collection.First().GetType();
        var propertiesNames = type.GetProperties().Where(p => p.Name != "EqualityContract");


        foreach (var propertyName in propertiesNames)
        {
            Console.Write(propertyName.Name);

            for (int i = 0; i < (lineTable.Length - propertyName.Name.Length) - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write(wallTable);
        }
        Console.WriteLine();
        for (int i = 0; i < propertiesNames.Count(); i++)
        {
            Console.Write(lineTable);
        }

        Console.WriteLine();
        foreach (var obj in collection)
        {
            foreach (var property in propertiesNames)
            {
                var properyValue = property.GetValue(obj);
                Console.Write(properyValue);

                for (int i = 0; i < (lineTable.Length - properyValue.ToString().Length) - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(wallTable);
            }
            Console.WriteLine();
        }
    }
}

public class UserInteraction : IUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public string AskUserForInput()
    {
        return Console.ReadLine();
    }
    public void ProccessUserInput(string userInput, IDataRepository dataRepository)
    {
        if (dataRepository.GetStats(userInput.ToLower()) is not null)
        {
            var planetsStats = dataRepository.GetStats(userInput.ToLower());
            var MaxStat = planetsStats.OrderByDescending(kv => kv.Value).FirstOrDefault();
            var MinStat = planetsStats.OrderBy(kv => kv.Value).FirstOrDefault();

            ShowMessage($"Max {userInput.ToLower()} is {MaxStat.Value} (planet: {MaxStat.Key})");
            ShowMessage($"Min {userInput.ToLower()} is {MinStat.Value} (planet: {MinStat.Key})");
        }
        else
        {
            ShowMessage("Invalid choice");
        }

        ShowMessage("Press any key to close.");
    }
}

public interface IDataRepository
{
    void AddKeyAndValueToPlanetsDiameter(string planet, string value);
    void AddKeyAndValueToPlanetsPopulation(string planet, string value);
    void AddKeyAndValueToPlanetsSurfaceWater(string planet, string value);
    string GetData();
    Dictionary<string, int>? GetStats(string dataName);
}

public class DataRepository : IDataRepository
{
    public Dictionary<string, int> planetsDiameter = new();
    public Dictionary<string, int> planetsSurfaceWater = new();
    public Dictionary<string, int> planetsPopulation = new();

    private Task<string> Data { get; init; }

    public DataRepository(Task<string> data)
    {
        Data = data;
    }

    public string GetData()
    {
        return Data.Result;
    }

    public void AddKeyAndValueToPlanetsDiameter(string planet, string value)
    {
        if (int.TryParse(value, out int parsedValue))
        {
            planetsDiameter[planet] = parsedValue;
        }
    }
    public void AddKeyAndValueToPlanetsSurfaceWater(string planet, string value)
    {
        if (int.TryParse(value, out int parsedValue))
        {
            planetsSurfaceWater[planet] = parsedValue;
        }

    }
    public void AddKeyAndValueToPlanetsPopulation(string planet, string value)
    {
        if (int.TryParse(value, out int parsedValue))
        {
            planetsPopulation[planet] = parsedValue;
        }
    }

    public Dictionary<string, int>? GetStats(string dataName)
    {
        if (dataName == "population")
        {
            return planetsPopulation;
        }
        else if (dataName == "surfacewater")
        {
            return planetsSurfaceWater;
        }
        else if (dataName == "diameter")
        {
            return planetsDiameter;
        }
        return null;
    }

}

#region Records objects for Json Deserialization

public record Result(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("diameter")] string Diameter,
    [property: JsonPropertyName("surface_water")] string SurfaceWater,
    [property: JsonPropertyName("population")] string Population
);

public record Root(
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);

#endregion