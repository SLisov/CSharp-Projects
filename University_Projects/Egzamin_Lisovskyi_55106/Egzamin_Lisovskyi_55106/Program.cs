using System;

namespace Egzamin_Lisovskyi_55106
{
    class pracownik_uczelni
    {
        public string imie;
        public string nazwisko;
        public string mes_pracy;
        public string tytul;
        public string badanie;
        public string przedmiot;
        public int lat;

        public void GetInfo()
        {
            Console.WriteLine($"Pracownik uczelni:");
            Console.WriteLine($"Imie: {imie}  Nazwisko: {nazwisko}");
            Console.WriteLine($"Tytuł Naukowy: {tytul}");
            Console.WriteLine($"Miejsce Pracy: {mes_pracy}");
            Console.WriteLine($"Dziedzina Badań Naukowych: {badanie}");
            Console.WriteLine($"Nauczane Przedmioty: {przedmiot}");
            Console.WriteLine($"Wiek: {lat}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            pracownik_uczelni Robert = new pracownik_uczelni();


            Robert.imie = "Robert";
            Robert.nazwisko = "Wiśniewski";
            Robert.tytul = "Dr.";
            Robert.mes_pracy = "Akademia Finansów i Biznesu Vistula";
            Robert.badanie = "Późna Starożytność";
            Robert.przedmiot = "Historia";
            Robert.lat = 48;

            Robert.GetInfo();  
            Console.ReadKey();
        }
    }
}
