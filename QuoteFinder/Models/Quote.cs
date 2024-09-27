using System.Text.Json.Serialization;
public record Quote(
    [property: JsonPropertyName("id")] int id,
    [property: JsonPropertyName("quote")] string quote,
    [property: JsonPropertyName("author")] string author
)
{
    public override string ToString()
    {
        return $"{quote} -- {author}.";
    }
};
