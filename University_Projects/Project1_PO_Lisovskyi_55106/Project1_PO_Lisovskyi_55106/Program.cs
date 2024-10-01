using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PO_Lisovskyi_55106
{
    struct Wektor : IComparable<Wektor>
    {
        public double wektor_X, wektor_Y, wektor_Z;
        readonly double dlugosc;

        public void setWek_X(double a)
        {
            this.wektor_X = a;
        }
        public void setWek_Y(double a)
        {
            this.wektor_Y = a;
        }
        public void setWek_Z(double a)
        {
            this.wektor_Z = a;
        }

        public double getWek_X()
        {
            return this.wektor_X;
        }
        public double getWek_Y()
        {
            return this.wektor_Y;
        }
        public double getWek_Z()
        {
            return this.wektor_Z;
        }
        public double getDlugosc()
        {
            return dlugosc;
        }

        public Wektor(double a=0, double b=0, double c=0)
        {
            wektor_X = a;
            wektor_Y = b;
            wektor_Z = c;

            dlugosc = Math.Sqrt((Math.Pow(wektor_X, 2) + Math.Pow(wektor_Y, 2) + Math.Pow(wektor_Z, 2)));
        }

        public static Wektor operator + ( Wektor a, Wektor b)
        {
            Wektor temp = new Wektor(a.wektor_X + b.wektor_X, a.wektor_Y + b.wektor_Y, a.wektor_Z + b.wektor_Z);
            return temp;
        }

        public static Wektor operator + (Wektor a)
        {
            return a;
        }

        public static Wektor operator - (Wektor a)
        {
            Wektor temp = new Wektor(-a.wektor_X, -a.wektor_Y, -a.wektor_Z);
            return temp;
        }

        public static Wektor operator - (Wektor a, Wektor b)
        {
            Wektor temp = new Wektor(a.wektor_X - b.wektor_X, a.wektor_Y - b.wektor_Y, a.wektor_Z - b.wektor_Z);
            return temp;
        }

        public static bool operator == (Wektor a, Wektor b)
        {
            if (a.wektor_X == b.wektor_X && a.wektor_Y == b.wektor_Y && a.wektor_Z == b.wektor_Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (Wektor a, Wektor b)
        {
            if (a.wektor_X != b.wektor_X || a.wektor_Y != b.wektor_Y || a.wektor_Z != b.wektor_Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double operator * (Wektor a, Wektor b)
        {
            return (a.wektor_X * b.wektor_X) + (a.wektor_Y * b.wektor_Y) + (a.wektor_Z * b.wektor_Z);
        }

        public static Wektor operator * (Wektor a, double b)
        {
            Wektor temp = new Wektor(a.wektor_X * b, a.wektor_Y * b, a.wektor_Z * b);
            return temp;
        }

        public static Wektor operator * (double b, Wektor a)
        {
            Wektor temp = new Wektor(a.wektor_X * b, a.wektor_Y * b, a.wektor_Z * b);
            return temp;
        }

        public static Wektor operator / (Wektor a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Nie mozna dzielic przez 0");
            }
            Wektor temp = new Wektor(a.wektor_X / b, a.wektor_Y / b, a.wektor_Z / b);
            return temp;
        }

        public static bool operator < (Wektor a, Wektor b)
        {
            if (a.dlugosc < b.dlugosc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator > (Wektor a, Wektor b)
        {
            if (a.dlugosc > b.dlugosc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Wektor operator ^ (Wektor a, Wektor b)
        {
            Wektor temp = new Wektor((a.wektor_Y * b.wektor_Z) - (a.wektor_Z * b.wektor_Y), (a.wektor_Z * b.wektor_X) - (a.wektor_X * b.wektor_Z), (a.wektor_X * b.wektor_Y) - (a.wektor_Y * b.wektor_X));
            return temp;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Wektor))
            {
                return false;
            }
            Wektor wek = (Wektor)obj;
            return (this == wek);
        }

        public override int GetHashCode()
        {
            return (int)(this.wektor_X + this.wektor_Y + this.wektor_Z);
        }

        public static double Dot(Wektor a, Wektor b)
        {
            return (a.wektor_X * b.wektor_X) + (a.wektor_Y * b.wektor_Y) + (a.wektor_Z * b.wektor_Z);
        }

        public static Wektor Cross(Wektor a, Wektor b)
        {
            Wektor temp = new Wektor((a.wektor_Y * b.wektor_Z) - (a.wektor_Z * b.wektor_Y), (a.wektor_Z * b.wektor_X) - (a.wektor_X * b.wektor_Z), (a.wektor_X * b.wektor_Y) - (a.wektor_Y * b.wektor_X));
            return temp;
        }

        public static bool Prostopadlosc(Wektor a, Wektor b)
        {
            if (Math.Acos((a * b) / (a.dlugosc * b.dlugosc)) == Math.PI/2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareTo(Wektor a)
        {
            double roznica = this.dlugosc - a.dlugosc;
            if (roznica != 0)
            {
                roznica /= Math.Abs(roznica);
            }
            return (int)(roznica);
        }

        public override string ToString()
        {
            return "[ " + this.wektor_X + " , " + this.wektor_Y + " , " + this.wektor_Z + " ]";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Project1_PO By Lisovskyi Stanislav 55106";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 30;
            Console.WindowWidth = 140;
            Console.Clear();

            Wektor a = new Wektor(3, -7.43, 21.9);
            Wektor b = new Wektor(2, 6.43, -20.7);
            Wektor wynik = new Wektor();
            wynik = a + b;
            Console.WriteLine($"\tOperator dodawania: {a.ToString()} + {b.ToString()} = {wynik.ToString()}\n");
            wynik = a - b;
            Console.WriteLine($"\tOperator dodawania: {a.ToString()} - {b.ToString()} = {wynik.ToString()}\n");
            wynik = +a;
            Console.WriteLine($"\tOperator +(jednoargumentowy): Wynik = {wynik.ToString()}\n");
            wynik = -a;
            Console.WriteLine($"\tOperator -(jednoargumentowy): Wynik = {wynik.ToString()}\n");
            Wektor c = new Wektor(3, -7.43, 21.9);
            if (c == a)
            {
                Console.WriteLine($"\tOperator równości: Wektory {c.ToString()} i {a.ToString()} są równe. \n");
            }
            else
            {
                Console.WriteLine($"\tOperator równości: Wektory {c.ToString()} i {a.ToString()} nie są równe. \n");
            }

            if (b != a)
            {
                Console.WriteLine($"\tOperator nierówności: Wektory {b.ToString()} i {a.ToString()} nie są równe. \n");
            }
            else
            {
                Console.WriteLine($"\tOperator nierówności: Wektory {b.ToString()} i {a.ToString()} są równe. \n");
            }

            if (a.Equals(b))
            {
                Console.WriteLine($"\tEquals: Wektory {a.ToString()} i {b.ToString()} są równe. \n");
            }
            else
            {
                Console.WriteLine($"\tEquals: Wektory {a.ToString()} i {b.ToString()} nie są równe. \n");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\tGetHashCode: \n");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine($"\ta = {a.ToString()} = {a.GetHashCode()}\n\tb = {b.ToString()} = {b.GetHashCode()}\n\t" +
                $"c = {c.ToString()} = {c.GetHashCode()} \n");
            double d = 0;
            d = Wektor.Dot(a, b);
            Console.WriteLine($"\tDot: {a.ToString()} * {b.ToString()} = {d} \n");
            wynik = Wektor.Cross(a, b);
            Console.WriteLine($"\tCross: {a.ToString()} X {b.ToString()} = {wynik.ToString()} \n");
            d = a * b;
            Console.WriteLine($"\tOperator *: {a.ToString()} * {b.ToString()} = {d} \n");
            wynik = a ^ b;
            Console.WriteLine($"\tOperator ^: {a.ToString()} X {b.ToString()} = {wynik.ToString()} \n");
            d = 3;
            Console.WriteLine($"\tWektor przed przemnożeniem przez {d}: {a} \n");
            a = a * d;
            Console.WriteLine($"\tWektor po przemnożeniu przez {d}: {a} \n");
            a = a / 3;
            Console.WriteLine($"\tWektor po podzieleniu przez {d}: {a} \n");
            a = d * a;
            Console.WriteLine($"\tWektor po przemnozeniu przez {d}: {a} \n");
            
            Wektor e = new Wektor(2, 4, 1);
            Wektor f = new Wektor(2, 1, -8);

            if (Wektor.Prostopadlosc(e, f))
            {
                Console.WriteLine($"\tWektory {e.ToString()} i {f.ToString()} są prostopadle. \n");
            }
            else
            {
                Console.WriteLine($"\tWektory {e.ToString()} i {f.ToString()} nie są prostopadle. \n");
            }

            if (Wektor.Prostopadlosc(e, a))
            {
                Console.WriteLine($"\tWektory {e.ToString()} i {a.ToString()} są prostopadle. \n");
            }
            else
            {
                Console.WriteLine($"\tWektory {e.ToString()} i {a.ToString()} nie są prostopadle. \n");
            }

            Wektor[] tablica = new Wektor[10];
            var rand = new Random();

            for (int i = 0; i < tablica.Length; i++)
            {
                tablica[i] = new Wektor(rand.Next(101), rand.Next(101), rand.Next(101));
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tPrzed sortowaniem: \n");
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (Wektor wek in tablica)
            {
                Console.WriteLine($"\t{wek.ToString()} - Długość: {wek.getDlugosc()} \n");
            }
            try
            {
                Array.Sort(tablica);
            }
            catch(Exception excep)
            {
                Console.WriteLine(excep.Message);
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\tPo sortowaniu: \n");
            Console.ForegroundColor = ConsoleColor.Black;

            foreach (Wektor wek in tablica)
            {
                Console.WriteLine($"\t{wek.ToString()} - Długość: {wek.getDlugosc()} \n");
            }
            if (e < f)
            {
                Console.WriteLine($"\tWektor {e.ToString()} długość: {e.getDlugosc()} jest mniejszy od wektora {f.ToString()}" +
                    $"długość {f.getDlugosc()} \n");
            }
            else
            {
                Console.WriteLine($"\tWektor {e.ToString()} długość: {e.getDlugosc()} jest większy od wektora {f.ToString()}" +
                    $"długość {f.getDlugosc()} \n");
            }

            if (e > a)
            {
                Console.WriteLine($"\tWektor {a.ToString()} długość: {a.getDlugosc()} jest mniejszy od wektora {e.ToString()}" +
                    $"długość {e.getDlugosc()} \n");
            }
            else
            {
                Console.WriteLine($"\tWektor {a.ToString()} długość: {a.getDlugosc()} jest większy od wektora {e.ToString()}" +
                    $"długość {e.getDlugosc()} \n");
            }
        }
    }
}
