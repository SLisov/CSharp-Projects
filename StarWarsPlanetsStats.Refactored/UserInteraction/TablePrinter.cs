public static class TablePrinter
{
    const int columnWidth = 15;

    public static void Print<T>(IEnumerable<T> collection)
    {
        var propertiesInfo = typeof(T).GetProperties();

        foreach (var property in propertiesInfo)
        {
            Console.Write($"{{0,-{columnWidth}}}|",property.Name);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', propertiesInfo.Length * (columnWidth +1)));
        foreach (var obj in collection)
        {
            foreach (var property in propertiesInfo)
            {
                Console.Write($"{{0,-{columnWidth}}}|",property.GetValue(obj));
            }
            Console.WriteLine();
        }
    }
}