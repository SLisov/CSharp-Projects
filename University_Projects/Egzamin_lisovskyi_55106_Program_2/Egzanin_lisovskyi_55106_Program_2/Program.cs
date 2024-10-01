using System;

namespace Egzanin_lisovskyi_55106_Program_2
{

    abstract class PaskudaChorobotwórcza
    {
        public string Imie { get; set; }
        public string Familia { get; set; }
        public string Wywołuje_chorób { get; set; }

        public PaskudaChorobotwórcza(string imie, string familia, string wywołuje_chorób)
        {
            Imie = imie;
            Familia = familia;
            Wywołuje_chorób = wywołuje_chorób;
        }
        
        public virtual void Display()
        {
            Console.WriteLine(Imie);
            Console.WriteLine(Familia);
            Console.WriteLine(Wywołuje_chorób);
        }
    }

    class Wirus : PaskudaChorobotwórcza
    {
        public string Wykrywanie { get; set; }
        public Wirus(string imie, string familia, string wywołuje_chorób, string wykrywanie)
            : base(imie)
        {
            Wykrywanie = wykrywanie;
        }
    }

    class Bakteria : PaskudaChorobotwórcza
    {
        public string Rozmiar { get; set; }
        public Bakteria(string imie, string familia, string wywołuje_chorób, string rozmiar)
            : base(imie)
        {
            Rozmiar = rozmiar;
        }
    }

    class Pierwotniak: PaskudaChorobotwórcza
    {
        public string Królestwo { get; set; }
        public Pierwotniak(string imie, string familia, string wywołuje_chorób, string królestwo)
            : base(imie)
        {
            Królestwo = królestwo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wirus wirus_grypy = new Wirus("Wirus grypy", "Orthomyxoviridae", "ryby, ptaki i ssaki", "1901");
            Bakteria Gronkowce = new Bakteria("Gronkowce", "Firmicutes", "ludzi i zwierząt", "0,6 - 1,2 mm");
            Pierwotniak protisty = new Pierwotniak("protisty", "Eukarionty", "ludzi i zwierząt", "Protozoa");
        }
    }
}
