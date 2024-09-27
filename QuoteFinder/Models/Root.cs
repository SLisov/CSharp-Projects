using System.Text.Json.Serialization;

public record Root(
    [property: JsonPropertyName("quotes")] IReadOnlyList<Quote> quotes,
    [property: JsonPropertyName("total")] int total,
    [property: JsonPropertyName("skip")] int skip,
    [property: JsonPropertyName("limit")] int limit
);
