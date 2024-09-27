using System.Globalization;
using System.Collections.Generic;
using Dumpify;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System;
using System.IO;
using static UglyToad.PdfPig.Core.PdfSubpath;

const string contentPath = @"Tickets";

try
{
    var app = new TicketsAggregationApp(new DocumentsReader(), new TextToFileWriter(), new TicketDataExtractor(), contentPath);
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An exception occurred. Exception message: " + ex.Message);
}
Console.WriteLine("Press any key to close.");
Console.ReadKey();
