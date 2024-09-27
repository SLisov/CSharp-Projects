using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using GameDataParser.Application;
using GameDataParser.DataAccess;
using GameDataParser.Logging;
using GameDataParser.Model;
using GameDataParser.UserInteraction;
namespace GameDataParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInteractions = new ConsoleUserInteraction();
            var runApp = new AppGameDataParser(userInteractions, new LocalFileReader(), new FileContentDeserializer(userInteractions), new FileDataPrinter(userInteractions));
            var logger = new Logs("logs.txt");

            try
            {
                runApp.AppRun();
            }
            catch (Exception ex)
            {
                logger.Log(ex);
                Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }

}
