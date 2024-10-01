using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr3_Lisovskyi55106
{
    public partial class Laboratorium : Form
    {
        const int SLMargines = 10; // margines do krawędzi powierzchni graficznej

        const ushort SLMarginesFormularz = 20; // margines od krawędzi formularza
        const ushort SLSzerokośćKolumny = 60; // kontrolki DataGridView
        const ushort SLWysokoścWiersza = 23; // kontrolki DataGridView
        const short SLBrakDrogi = short.MaxValue; // brak drogi między węzłami

        // deklaracja macierzy opisu grafu
        ushort SLLiczbaWierzchołkówGrafu;
        static int[,] SLMacierzWag; // macierz Wag/Sąsiedztwa
        static int[,] SLMacierzOdległości; // macierz najkrótszych ścieżek (tras) grafu
        static int[,] SLMacierzWęzłówPośrednich;// macierz węzłów pośrednich dla ścieżek (tras) w grafie 
        public Laboratorium()
        {
            InitializeComponent();
        }

        private void SLbtnMacierzWag_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolki errorProvider1, która może byc "zapalona"
            SLerrorProvider1.Dispose();
            // pobranie liczby węzłów grafu
            if (!ushort.TryParse(SLtxtLiczbaWierzchołkówGrafu.Text, out SLLiczbaWierzchołkówGrafu))
            {
                SLerrorProvider1.SetError(SLtxtLiczbaWierzchołkówGrafu, "ERROR: wystąpił niedozwolony znak w zapisie" +
                    "liczby węzłów grafu");
                return;
            }
            SLlblMacierzWag.Visible = true;

            // okresłenie lokalizacji i rozmiarów kontrolki kadgvMacierzWag
            SLdgvMacierzWag.Size = new Size((SLLiczbaWierzchołkówGrafu + 1) * SLSzerokośćKolumny,
                (SLLiczbaWierzchołkówGrafu + 1) * SLWysokoścWiersza);
            // ustawienie trybu AutoResizeRows dla wierzsy kontrolki DataGradView
            SLdgvMacierzWag.AutoResizeRows();
            // przypisanie kontrolce dgvMacierzWag liczby kolumn
            SLdgvMacierzWag.ColumnCount = SLLiczbaWierzchołkówGrafu;
            // odsłonięcie wiersza nagłówkowego (HEADER) dla kolumn
            SLdgvMacierzWag.ColumnHeadersVisible = true;
            // zezwolenie na odczytywanie i wpisywanie wartóści elementów kontolki DataGridView
            SLdgvMacierzWag.ReadOnly = false;
            // uniemożliwienia dodawania nowych wierszy do kontrolki DataGridView
            SLdgvMacierzWag.AllowUserToAddRows = false;
            // ustawienie trybu AutoSize dla nagłówka kolumn kontrolki DataGridView
            SLdgvMacierzWag.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // uniemożliwienie selekcji wielu komórek kontrolki DataGridView
            SLdgvMacierzWag.MultiSelect = false;
            // sformotowanie opisu nagłówka (HEADERa) kolumn kontrolce DataGridView
            DataGridViewCellStyle SLStylHeaderaKolumn = new DataGridViewCellStyle();
            SLStylHeaderaKolumn.Font = new Font("Arial", 10, FontStyle.Bold);
            SLStylHeaderaKolumn.Alignment = DataGridViewContentAlignment.MiddleLeft;
            SLStylHeaderaKolumn.Format = " ";
            // przypisanie egzemplarza stylu nagłówka (HEADERa) kolumn do kontrolki dgvMacierzWag
            SLdgvMacierzWag.ColumnHeadersDefaultCellStyle = SLStylHeaderaKolumn;
            // sformotowanie opisu nagłówka (HEADERa) wierzy kontrolki DataGridView
            DataGridViewCellStyle SLStylHeaderaWierzy = new DataGridViewCellStyle();
            SLStylHeaderaWierzy.Font = new Font("Arial", 10, FontStyle.Bold);
            SLStylHeaderaWierzy.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // przypisanie egzemplarza stylu nagłówka (HEADERa) wierzy kontrolce dgvMacierzWag
            SLdgvMacierzWag.RowHeadersDefaultCellStyle = SLStylHeaderaWierzy;
            // wpisanie numerów kolumn w kontrolce dgvMacierzWag

            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
            {// wpisanie numeru kolumny
                SLdgvMacierzWag.Columns[i].HeaderText = "(" + i + ")";
                SLdgvMacierzWag.Columns[i].Width = SLSzerokośćKolumny;
            }
            // dodanie wierzy do kontrolki kadgvMacierzWag
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                SLdgvMacierzWag.Rows.Add();

            // wpisanie numerów wierszy w Headerze wierzy kontrolce dgvMacierzWag
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                SLdgvMacierzWag.Rows[i].HeaderCell.Value = "(" + i + ")";

            //ustawienie AutoResize dla nagłowków kontrolki dgvMacierzWag
            SLdgvMacierzWag.AutoResizeRowHeadersWidth
                (DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            SLdgvMacierzWag.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SLdgvMacierzWag.AutoResizeColumnHeadersHeight();
            SLdgvMacierzWag.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // dodanie egzemplarza kontrolki dgvMacierzWag do kolekcju Controls formularza
            Controls.Add(SLdgvMacierzWag);

            // "wyczyszczenie komórek w kontrolce dgvNacierzWag ( ma być pusta ! )
            for (ushort i = 0; i < SLdgvMacierzWag.Rows.Count; i++)
                for (ushort j = 0; j < SLdgvMacierzWag.Columns.Count; j++)
                    SLdgvMacierzWag.Rows[i].Cells[j].Value = "";

            // ustawienie stanu braku aktywnościdla obsługiwanego przecisku poleceń: btnUtwórzDataGridViewDlaMacierzyA
            SLbtnMacierzWag.Enabled = false;
            SLtxtLiczbaWierzchołkówGrafu.Enabled = false;
            // uaktywnienie kolejnych (nastęonych) przyciśków poleceń
            SLbtnPrzykładowaMacierzWag.Enabled = true;
            SLbtnAkceptacjaMacierzyWag.Enabled = true;
        }

        private void SLbtnPrzykładowaMacierzWag_Click(object sender, EventArgs e)
        {
            int[,] SLPrzykładowyGraf = { { SLBrakDrogi, SLBrakDrogi, SLBrakDrogi, 3, SLBrakDrogi},
                {3, SLBrakDrogi, 4, 1, SLBrakDrogi, },
                {SLBrakDrogi,-1,SLBrakDrogi,2,SLBrakDrogi },
                {-2,5,SLBrakDrogi,SLBrakDrogi,2 },
                {SLBrakDrogi,SLBrakDrogi,1,SLBrakDrogi,SLBrakDrogi },
                };
            if (SLLiczbaWierzchołkówGrafu != 5)
            {
                SLerrorProvider1.SetError(SLbtnAkceptacjaMacierzyWag, "ERORR: przykładowa" +
                    "macierz wag może byc wstawiona tylko dla grafu o 5 węzłach");
                return;
            }
            SLerrorProvider1.Dispose();
            // wpisanie do kontrolki DataGridView elementów macierzy X
            for (ushort i = 0; i < SLdgvMacierzWag.Rows.Count; i++)
                for (ushort j = 0; j < SLdgvMacierzWag.Columns.Count; j++)
                    if (SLPrzykładowyGraf[i, j] == SLBrakDrogi)
                        SLdgvMacierzWag.Rows[i].Cells[j].Value = "";
                    else
                        SLdgvMacierzWag.Rows[i].Cells[j].Value = SLPrzykładowyGraf[i, j];
            // string.Format("{0:F2}", PrzykładowyGraf[i,j]);
        }

        private void SLbtnAkceptacjaMacierzyWag_Click(object sender, EventArgs e)
        {
            SLerrorProvider1.Dispose(); // zgaszenie kontrolki errorProvider1
            // ustawić tryb ReadOnly dla kontrolki dgvMacierzWag
            SLdgvMacierzWag.ReadOnly = true;
            // lub        kadgvMacierzWag.Enabled = false;

            // ustawienie stanu braku aktywności dla obsługiawnego przycisku poleceń:
            // kabntnAkceptacjaElementówMacierzyA

            SLbtnAkceptacjaMacierzyWag.Enabled = false;
            SLbtnPrzykładowaMacierzWag.Enabled = false;
            // uktywnienie przycisku polecenia btnWyznaczŚcieżkiWgrafie
            SLbtnWyznaczŚcieżkiWgrafie.Enabled = true;

        }
        class SLGraf_MacierzWag // deklaracja klasy 
        {
            const short SLBrakDrogi = short.MaxValue; // brak drogi między węzłami
            int[,] SLmacierzWag;
            int[,] SLMacierzOdległości;
            int[,] SLMacierzWęzlówPośrednich;

            public SLGraf_MacierzWag(int[,] SLMacierzWag) // konstruktor
            { // skopiowanie MacierzWag
                SLmacierzWag = (int[,])SLMacierzWag.Clone(); // Clone() - klonowanie macierzy
                // utworzenie egzemplarza dla MacierzOdległości
                SLMacierzOdległości = new int[SLmacierzWag.GetLength(0), SLmacierzWag.GetLength(1)];
                // skopiowanie MacierzWag (zgodnie z wymogiem algorytmu Floyda - Warshalla
                SLMacierzOdległości = (int[,])SLmacierzWag.Clone();
                /* w macierzy MacierzOdległości na głównej prekątnej ustawiamy BrakDrogi,
                 aby wykluczyć pętle(krawędzi wychodzi i wraca do tego samego węzła) w
                grafie: algorytmu Floyda_Warshalla nie akceptuje grafów z pętlami */
                for (int j = 0; j < SLMacierzWag.GetLength(0); j++)
                    for (int i = 0; i < SLMacierzWag.GetLength(1); i++)
                        if (j == i)
                            /*  w macierzy odległości na głównej przekątnej ustawiamy BrakDrogi, aby
                                wykluczyć pętle ( krawędzi wychodzi i wraca do tego samego węzła) w
                                grafie: algorytm Floyda_Warshalla nie akceptuje grafów z pętlami 
                             
                            */
                            SLMacierzOdległości[j, i] = SLBrakDrogi;


                // utworzenie egzemplarza dla MacierzWęzłówPośrednich
                SLMacierzWęzłówPośrednich = new int[SLmacierzWag.GetLength(0), SLmacierzWag.GetLength(1)];
                // wyzerowanie macierzy węzłów pośrednich
                //for (int j = 0; j < kaMacierzWęzłówPośrednich.GetLength(0); j++)
                //{
                //   //for(int i = 0; i < kaMacierzWęzlówPośrednich.GetLength(1); i++)
                //   // {
                //   //     kaMacierzWęzłówPośrednich[j, i] = 0;
                //   // }
                //}


            }

            public void SLAlgorytm_Floyda_Warshalla(out int[,] SLModległóści, out int[,] SLMpośrednia)
            {
                /* Relaksacja (inaczej: osłabiania ograniczeń) krawędzi (u,v) w grafie polega na sprawdzaniu, 
                 czy możemy poprawic lepszą ścieżkę(drogę) z węzła j do węzłą i, jeśli droga będzie wiodła 
                 przez wierzchołek pośredi k */

                // algorytmu Floyda_Warshalla wyszukiwania najkrótszych dróg w grafie
                for (int k = 0; k < SLmacierzWag.GetLength(0); k++)
                    for (int j = 0; j < SLMacierzOdległości.GetLength(0); j++)
                        for (int i = 0; i < SLMacierzOdległości.GetLength(1); i++)
                            if ((SLMacierzOdległości[j, k] + SLMacierzOdległości[k, i]) < SLMacierzOdległości[j, i])
                            {
                                SLMacierzOdległości[j, i] = SLMacierzOdległości[j, k] + SLMacierzOdległości[k, i];
                                SLMacierzWęzłówPośrednich[j, i] = k;
                            }

                // przekazanie (przesłanie przez parametry wyjściowe metody) wyników
                SLModległóści = SLMacierzOdległości;
                SLMpośrednia = SLMacierzWęzłówPośrednich;

            }
        }

        private void SLbtnWyznaczŚcieżkiWgrafie_Click(object sender, EventArgs e)
        {
            // utworzenie egzemplarzy macierzy dla algorytmu Floyda-Warshalla 
            SLMacierzWag = new int[SLLiczbaWierzchołkówGrafu, SLLiczbaWierzchołkówGrafu];
            /* pobranie 'macierzy wag' z kontorlki dgvMacierzWag (kontrolki DataGridView), 
             która została umieszczona na formularzu */
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                for (ushort j = 0; j < SLLiczbaWierzchołkówGrafu; j++)
                    if (string.IsNullOrEmpty((SLdgvMacierzWag.Rows[i].Cells[j].Value).ToString()))
                        SLMacierzWag[i, j] = SLBrakDrogi;
                    else
                    if (!int.TryParse((SLdgvMacierzWag.Rows[i].Cells[j].Value).ToString(), out SLMacierzWag[i, j]))
                    {
                        SLerrorProvider1.SetError(SLdgvMacierzWag, "ERROR: w zapisie elementu " +
                            "kontrolki DataGridView o indeksie: [" + i + ", " + j + "]\t wystąpił niedozwolony znak");
                        return;

                    }
            // utworzenie egzemplarza grafu

            SLGraf_MacierzWag stGraf = new SLGraf_MacierzWag((int[,])SLMacierzWag.Clone());
            // wywołanie metody (algorytmu) Floyda-Warshalla
            stGraf.SLAlgorytm_Floyda_Warshalla(out SLMacierzOdległości, out SLMacierzWęzłówPośrednich);


            // kontrolka DataGridView dla wpisania najkrószych między węzłami grafu
            Kontrolka_SLdgvMacierzOdległości();
            // wpisanie danych z macierzy MacierzOdległość do kontrolki dgvMacierzOdległości
            for (ushort i = 0; i < SLdgvMacierzOdległości.Rows.Count; i++)
                for (ushort j = 0; j < SLdgvMacierzOdległości.Columns.Count; j++)
                    SLdgvMacierzOdległości.Rows[i].Cells[j].Value = SLMacierzOdległości[i, j];
            //string.Format("{0:F2})", MacierzOdległoś[i, j]);
            // ustawienia trybu ReadOnly dla kontrolki dgvMacierzOdległości
            SLdgvMacierzOdległości.ReadOnly = true;
            // kontrolka DataGridView dla wpisania macierzy węzłów pośrednich
            Kontrolka_SLdgvMacierzWęzłówPośrednich();
            // wpisanie danych z macierzy MacierzWęzłóPośrednich do kontrolki dgvMacierzWęzłówPośrednich
            for (ushort i = 0; i < SLdgvMacierzOdległości.Rows.Count; i++)
                for (ushort j = 0; j < SLdgvMacierzOdległości.Columns.Count; j++)
                    SLdgvMacierzWęzłówPośrednich.Rows[i].Cells[j].Value = SLMacierzWęzłówPośrednich[i, j];
            // ustawienie trybu ReadOnly dla kontrolki dgvMacierzWęzłówPośrednich
            SLdgvMacierzWęzłówPośrednich.ReadOnly = true;
            // ustawienie stanu braku aktywności dla przycisku poleceń
            SLbtnWyznaczŚcieżkiWgrafie.Enabled = false;
        }

        private void SLdgvMacierzOdległości_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Kontrolka_SLdgvMacierzOdległości()
        {
            SLlblMacierzOdległości.Visible = true;
            // okresłenie lokalizacji i rozmiarów kontrolki kadgvMacierzOdległości
            SLdgvMacierzOdległości.Size = new Size((SLLiczbaWierzchołkówGrafu + 1) * SLSzerokośćKolumny,
                (SLLiczbaWierzchołkówGrafu + 1) * SLWysokoścWiersza);
            // ustawienie trybu AutoResizeRows dla wierzsy kontrolki DataGradView
            SLdgvMacierzOdległości.AutoResizeRows();
            // przypisanie kontrolce dgvMacierzWag liczby kolumn
            SLdgvMacierzOdległości.ColumnCount = SLLiczbaWierzchołkówGrafu;
            // odsłonięcie wiersza nagłówkowego (HEADER) dla kolumn
            SLdgvMacierzOdległości.ColumnHeadersVisible = true;
            // zezwolenie na odczytywanie i wpisywanie wartóści elementów kontolki DataGridView
            SLdgvMacierzOdległości.ReadOnly = false;
            // uniemożliwienia dodawania nowych wierszy do kontrolki DataGridView
            SLdgvMacierzOdległości.AllowUserToAddRows = false;
            // ustawienie trybu AutoSize dla nagłówka kolumn kontrolki DataGridView
            SLdgvMacierzOdległości.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // uniemożliwienie selekcji wielu komórek kontrolki DataGridView
            SLdgvMacierzOdległości.MultiSelect = false;
            // sformotowanie opisu nagłówka (HEADERa) kolumn kontrolce DataGridView
            DataGridViewCellStyle SLStylHeaderaKolumn = new DataGridViewCellStyle();
            SLStylHeaderaKolumn.Font = new Font("Arial", 10, FontStyle.Bold);
            SLStylHeaderaKolumn.Alignment = DataGridViewContentAlignment.MiddleLeft;
            SLStylHeaderaKolumn.Format = " ";
            // przypisanie egzemplarza stylu nagłówka (HEADERa) kolumn do kontrolki 
            SLdgvMacierzOdległości.ColumnHeadersDefaultCellStyle = SLStylHeaderaKolumn;
            // sformotowanie opisu nagłówka (HEADERa) wierzy kontrolki DataGridView
            DataGridViewCellStyle SLStylHeaderaWierzy = new DataGridViewCellStyle();
            SLStylHeaderaWierzy.Font = new Font("Arial", 10, FontStyle.Bold);
            SLStylHeaderaWierzy.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // przypisanie egzemplarza stylu nagłówka (HEADERa) wierzy kontrolce
            SLdgvMacierzOdległości.RowHeadersDefaultCellStyle = SLStylHeaderaWierzy;

            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
            {// wpisanie numeru kolumny
                SLdgvMacierzOdległości.Columns[i].HeaderText = "(" + i + ")";
                SLdgvMacierzOdległości.Columns[i].Width = SLSzerokośćKolumny;
            }
            // dodanie wierzy do kontrolki kadgvMacierzWag
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                SLdgvMacierzOdległości.Rows.Add();

            // wpisanie numerów wierszy w Headerze wierzy kontrolce dgvMacierzWag
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                SLdgvMacierzOdległości.Rows[i].HeaderCell.Value = "(" + i + ")";

            //ustawienie AutoResize dla nagłowków kontrolki dgvMacierzWag
            SLdgvMacierzOdległości.AutoResizeRowHeadersWidth
                (DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            SLdgvMacierzOdległości.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SLdgvMacierzOdległości.AutoResizeColumnHeadersHeight();
            SLdgvMacierzOdległości.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        public void Kontrolka_SLdgvMacierzWęzłówPośrednich()
        {
            SLlblMacierzWęzłów.Visible = true;
            // okresłenie lokalizacji i rozmiarów kontrolki kadgvMacierzOdległości
            SLdgvMacierzWęzłówPośrednich.Size = new Size((SLLiczbaWierzchołkówGrafu + 1) * SLSzerokośćKolumny,
                (SLLiczbaWierzchołkówGrafu + 1) * SLWysokoścWiersza);
            // ustawienie trybu AutoResizeRows dla wierzsy kontrolki DataGradView
            SLdgvMacierzWęzłówPośrednich.AutoResizeRows();
            // przypisanie kontrolce dgvMacierzWag liczby kolumn
            SLdgvMacierzWęzłówPośrednich.ColumnCount = SLLiczbaWierzchołkówGrafu;
            // odsłonięcie wiersza nagłówkowego (HEADER) dla kolumn
            SLdgvMacierzWęzłówPośrednich.ColumnHeadersVisible = true;
            // zezwolenie na odczytywanie i wpisywanie wartóści elementów kontolki DataGridView
            SLdgvMacierzWęzłówPośrednich.ReadOnly = false;
            // uniemożliwienia dodawania nowych wierszy do kontrolki DataGridView
            SLdgvMacierzWęzłówPośrednich.AllowUserToAddRows = false;
            // ustawienie trybu AutoSize dla nagłówka kolumn kontrolki DataGridView
            SLdgvMacierzWęzłówPośrednich.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // uniemożliwienie selekcji wielu komórek kontrolki DataGridView
            SLdgvMacierzWęzłówPośrednich.MultiSelect = false;
            // sformotowanie opisu nagłówka (HEADERa) kolumn kontrolce DataGridView
            DataGridViewCellStyle SLStylHeaderaKolumn = new DataGridViewCellStyle();
            SLStylHeaderaKolumn.Font = new Font("Arial", 10, FontStyle.Bold);
            SLStylHeaderaKolumn.Alignment = DataGridViewContentAlignment.MiddleLeft;
            SLStylHeaderaKolumn.Format = " ";
            // przypisanie egzemplarza stylu nagłówka (HEADERa) kolumn do kontrolki 
            SLdgvMacierzWęzłówPośrednich.ColumnHeadersDefaultCellStyle = SLStylHeaderaKolumn;
            // sformotowanie opisu nagłówka (HEADERa) wierzy kontrolki DataGridView
            DataGridViewCellStyle SLStylHeaderaWierzy = new DataGridViewCellStyle();
            SLStylHeaderaWierzy.Font = new Font("Arial", 10, FontStyle.Bold);
            SLStylHeaderaWierzy.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // przypisanie egzemplarza stylu nagłówka (HEADERa) wierzy kontrolce
            SLdgvMacierzWęzłówPośrednich.RowHeadersDefaultCellStyle = SLStylHeaderaWierzy;

            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
            {// wpisanie numeru kolumny
                SLdgvMacierzWęzłówPośrednich.Columns[i].HeaderText = "(" + i + ")";
                SLdgvMacierzWęzłówPośrednich.Columns[i].Width = SLSzerokośćKolumny;
            }
            // dodanie wierzy do kontrolki kadgvMacierzWag
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                SLdgvMacierzWęzłówPośrednich.Rows.Add();

            // wpisanie numerów wierszy w Headerze wierzy kontrolce dgvMacierzWag
            for (ushort i = 0; i < SLLiczbaWierzchołkówGrafu; i++)
                SLdgvMacierzWęzłówPośrednich.Rows[i].HeaderCell.Value = "(" + i + ")";

            //ustawienie AutoResize dla nagłowków kontrolki dgvMacierzWag
            SLdgvMacierzWęzłówPośrednich.AutoResizeRowHeadersWidth
                (DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            SLdgvMacierzWęzłówPośrednich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SLdgvMacierzWęzłówPośrednich.AutoResizeColumnHeadersHeight();
            SLdgvMacierzWęzłówPośrednich.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void SLLaboratorium_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
