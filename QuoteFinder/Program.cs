using System.Linq;
using System.Text.Json;

var quotesRepository = new QuotesRepository();
var app = new App(quotesRepository, new ApiGetQuotes(),
    new ConsoleUserInteraction(quotesRepository));

try
{
    await app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Unexpectged exception: " + ex.Message);
}

Console.WriteLine("Program is finished.");
Console.ReadLine();
