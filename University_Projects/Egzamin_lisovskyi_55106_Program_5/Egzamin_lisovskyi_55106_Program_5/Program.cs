using System;

namespace Egzamin_lisovskyi_55106_Program_5
{
    class BardzoDziwneLiczby
    {
        static void Main(string[] args)
        {
            int a;
            int b;

            double c;
            double d;

            Console.Write("\n\t Wpisz pierwszą cyfrę: ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("\n\t ERROR: W zapisie musi być całkowita liczba i nie powinno być liter");
                Console.Write("\n\t Podaj ponownie: ");
            }
            Console.Write("\n\t Wpisz drugą cyfrę: ");
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("\n\t ERROR: W zapisie musi być całkowita liczba i nie powinno być liter");
                Console.Write("\n\t Podaj ponownie: ");
            }
            c = b * Math.Sqrt(3);
            d = a + c;
            Console.WriteLine("\n\t Wynik " + d.ToString());
        }
    }
}
