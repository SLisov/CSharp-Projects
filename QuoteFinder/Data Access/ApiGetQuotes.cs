using System.Text.Json;

internal class ApiGetQuotes : IGetQuotesFrom
{
    public async Task<Root> GetQuotesAsync(int amount)
    {
        string baseAddress = $"https://dummyjson.com/quote?limit={amount}";
        using var httpClient = new HttpClient();
        var httpResponse = new HttpResponseMessage();

        httpResponse = await httpClient.GetAsync(baseAddress);
        httpResponse.EnsureSuccessStatusCode();
        var json = await httpResponse.Content.ReadAsStringAsync();
        var root = JsonSerializer.Deserialize<Root>(json);
        return root!;
    }
}
