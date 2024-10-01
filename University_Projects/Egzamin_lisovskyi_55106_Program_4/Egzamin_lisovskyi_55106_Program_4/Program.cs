using System;

namespace Egzamin_lisovskyi_55106_Program_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {

                    try
                    {
                        double a, n, c;
                        Console.Write("\n\t Wpisz liczbe: ");
                        while (!double.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("\n\t ERROR: w zapisie nie moze byc liter!!!");
                            Console.Write("\n\t Podaj ponownie: ");
                        }
                        n = 1 / 4;
                        c = Math.Pow(a, n);
                        Console.Write("\n\t Wynik: " + c);
                    }
                    catch
                    {
                        Console.Write("\n\t Cos poszlo nie tak");
                    }
                }
            }
            finally
            {
                Console.WriteLine("\n\t Koniec");
                Console.Read();
            }

        }

    }
}
