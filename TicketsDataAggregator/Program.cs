using System.Collections.Generic;
using Dumpify;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.IO;

const string contentPath = @"Tickets";

try
{
    var app = new App(new PdfReader(), new TextToFileWriter(), new TicketDataExtractor(new CultureRecognizer()));
    app.Run(contentPath);
}
catch (Exception ex)
{
    Console.WriteLine("An exception occurred. Exception message: " + ex.Message);
}

Console.ReadLine();
internal class App
{
    private IFileReader _fileReader;
    private IFileWriter _fileWriter;
    private IDataExtractor _dataExtractor;

    public App(IFileReader fileReader,
        IFileWriter fileWriter,
        IDataExtractor dataExtractor)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
        _dataExtractor = dataExtractor;
    }

    public void Run(string path)
    {
        var text = _fileReader.Read(path);
        IEnumerable<string> ticketsCollection = _dataExtractor.ToTicket(text!)!;
        _fileWriter.Write(ticketsCollection);

        Console.WriteLine("Done!");
    }
}