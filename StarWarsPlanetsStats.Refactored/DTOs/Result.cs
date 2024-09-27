using System.Text.Json.Serialization;

public record Result(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("diameter")] string Diameter,
    [property: JsonPropertyName("surface_water")] string SurfaceWater,
    [property: JsonPropertyName("population")] string Population
);