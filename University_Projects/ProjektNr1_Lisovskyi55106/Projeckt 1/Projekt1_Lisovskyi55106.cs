using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Projekt1_Lisovskyi55106
{
    public partial class Projekt1_LisovskyiStanislav55106 : Form
    {
        /*deklaracja tablicy zezwoleń otwarcia stron (kart) kontenera TabControl*/
        bool[] SLStanStronZakladki = { true, false, false };
        const int SLMargines = 20;
        const int SLMaxLicznoscNominalow = 100;
        const int SLBanknotOnajniszejWartosci = 10;

        /* deklaracja tablicy dla przechowania wartosci nominalow w PLN*/
        float[] SLWartoscNominalow = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5F, 0.2F, 0.1F };
        // pomocnicza deklaracja struktury (rekord) opisującej element pojemnika nominalow

        struct SLNominaly
        {
            public ushort SLLicznosc;
            public float SLWartosc;
        }
        // deklaracja pojemnika nominalow
        SLNominaly[] SLPojemnikNominalow;
        /* deklaracje zmiennych referencyjnych kontrolek umieszczanych na 
           formularzu dynamicznie (w czasie działania programu) */

        TextBox txtDolnaGranicaPrzedzialu = new TextBox();
        TextBox txtGornaGranicaPrzdizualu = new TextBox();
        Button btnPrzycziskAkceptacjaNominalow = new Button();
        Label lblEtiketkaDolnejGranicaPrzedzialu = new Label();
        Label lblEtiketkaGorneyGranicaPrzedzialu = new Label();
        bool SLKontrolkiDodaneDoFormularza = false;
        public Projekt1_LisovskyiStanislav55106()
        {
            InitializeComponent();
            // ustawienie (otwarcie) zakladki tabPagePulpit
            SLZakladki.SelectedTab = SLtabPagePulpit;
            // lokalizacja i zwymiarowanie formularza
            this.Left = Screen.PrimaryScreen.Bounds.Left + SLMargines;
            this.Top = Screen.PrimaryScreen.Bounds.Top + SLMargines;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Width * 0.5);
            this.StartPosition = FormStartPosition.Manual; // jest konieczne!!!
            SLPojemnikNominalow = new SLNominaly[SLWartoscNominalow.Length];

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SLZakladki_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // identyfikacja wybranej (np. klięknięciem) strony kontenera Zakładki
            if (e.TabPage == SLZakladki.TabPages[0]) // czy to jest stron (karta) Pulpit
                // sprawdzenie, czy to jest zezwolenie na jej otwarcie
                if (SLStanStronZakladki[0])
                { // jest zezwolenie na jej uaktywnienie (otwarcie)
                    e.Cancel = false; // Cancel ustawiamy na false, gdyż przejście jest dozwolone
                    SLZakladki.SelectedTab = SLtabPagePulpit; // odsłonięcie strony (karty) Pulpit
                }
                else
                    e.Cancel = true; /* nie ma zezwolenia na przejścia do zakładki Pulpit i musi być skasowane, czyli Cancel ustawiamy na true */
            else
                if (e.TabPage == SLZakladki.TabPages[1]) // czy to jest stron (karta) Bankomat
                // sprawdzenie, czy jest zezwolenie na jej otwarcie
                if (SLStanStronZakladki[1])
                { // jest zezwolenie na jej uaktywnienie ( otwarcie)
                    e.Cancel = false; // Cancel ustawiamy na false, gdyż przejście jest dozwolone
                    SLZakladki.SelectedTab = SLtabPageBankomat; // odsłonięcie strony 9karty0 Bankomat
                }
                else
                    e.Cancel = true; /* nie ma zezwolenia na przejścia do zakładki Pulpit i musi
                                        być skasowane, czyli Cancel ustawiamy na true */

            else
                if (e.TabPage == SLZakladki.TabPages[2]) // czy to jest stron (karta) AutomatVendingowy
                // sprawdzenie, czy jest zezwolenie na jej otwarcie
                if (SLStanStronZakladki[2])
                { // jest zezwolenie na jej uaktywnienie (otwarcie)
                    e.Cancel = false; // Cancel ustawiamy na false, gdyż przejście jest dozwolone
                    SLZakladki.SelectedTab = SLtabPageAutomatVendingowy; /* odsłonięcie strony (karty) Automat Vendngowy */
                }
                else
                    e.Cancel = true; /* nie ma zezwolenia na przejścia do zakładki Pulpit i musi być skasowane, czyli ustawiamy na true */

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SLbtnBankomat_Click_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejcie do strony Pulpit,
              gdyż ma nastąpić przejście do strony Bankomat */
            SLStanStronZakladki[0] = false;
            // zezwolenie na przejście do strony Bankomat
            SLStanStronZakladki[1] = true;
            // realizacja przejście do strony Bankomat
            SLZakladki.SelectedTab = SLtabPageBankomat;
            // lub : Zakladki.TabIndex = 1;
        }

        private void SLbtnAutomatVendingowy_Click_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejcie do strony Pulpit,
              gdyż ma nastąpić przejście do strony AutomatVendingowy */
            SLStanStronZakladki[0] = false;
            // zezwolenie na przejście do strony Bankomat
            SLStanStronZakladki[2] = true;
            // realizacja przejście do strony Bankomat
            SLZakladki.SelectedTab = SLtabPageAutomatVendingowy;
            // lub : Zakladki.TabIndex = 2;
        }

        private void SLbtnPowrot_z_Bankomatu_Click_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejście do strony Bankomat,
               gdyż ma nastąpić przejście do strony Pulpit */
            SLStanStronZakladki[1] = false;
            // zezwolenie na przejście do strony Bankomat
            SLStanStronZakladki[0] = true;
            // realizacja przejście do strony Bankomat
            SLZakladki.SelectedTab = SLtabPagePulpit;
            // lub : Zakladki.TabIndex = 0;
        }

        private void SLbtnAkceptacjaLicznosci_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolki errorProvider1, ktOra mogła być zapalona
            ErrorProvider1.Dispose();
            // spradzenie, czy dokonano wyboru waluty
            if (SLcmbRodzajWaluty.SelectedIndex < 0)
            {
                ErrorProvider1.SetError(SLcmbRodzajWaluty, "ERROR: musisz wybrać walutę wypłaty");
                return;
            }
            // spradzenie, czy wybrano sposób ustalenia liczności nominałów
            if (!(SLrdbUstawienieLicznosciDomyslne.Checked || SLrdbUstawieniePrzedzialuLicznosci.Checked))
            {
                ErrorProvider1.SetError(groupBox1, "ERROR: musisz wybrać sposób ustalenia liczności nominałów");
                return;
            }
            // tutaj wszystko jest już OK!
            // identyfikacja wybranej kontrolki RadioButton do ustalenia liczności nominałów
            if (SLrdbUstawienieLicznosciDomyslne.Checked)  // dla kontrolki: losowe
            {
                // losowe ustalenie liczności nominałów
                Random rnd = new Random();
                // ustalenie liczności nominałów
                for (ushort i = 0; i < SLPojemnikNominalow.Length; i++)
                {
                    SLPojemnikNominalow[i].SLWartosc = SLWartoscNominalow[i];
                    SLPojemnikNominalow[i].SLLicznosc = (ushort)(rnd.Next(SLMaxLicznoscNominalow));
                }
                /*wizualizacja liczności nominałów: odsłonęcie kontrolek i wpisanie liczności
                 * nominałów do kontrolki DataGridView */
                SLlblWyplaconeNominaly.Visible = true;
                SLdgvListaNominalow.Visible = true;
                //wpisanie danych z pojemnika nominałów
                SLdgvListaNominalow.Rows.Clear(); //czyszczenie kontrolki ze "starych" danych
                //uaktualnienie tekstu kontrolki label: lblWyplaconeNominaly
                SLlblWyplaconeNominaly.Text = "Liczności nominalów Bankomatu";
                //przepisanie danych z pojemnika nominalow do kontrolki dataGridView1
                for (int i = 0; i < SLPojemnikNominalow.Length; i++)
                {
                    //dodanie nowego wiersza
                    SLdgvListaNominalow.Rows.Add();
                    //wpisanie odpowiednich danych do poszczegolnych kolumn wiersza
                    SLdgvListaNominalow.Rows[i].Cells[0].Value = SLPojemnikNominalow[i].SLLicznosc;
                    SLdgvListaNominalow.Rows[i].Cells[1].Value = SLPojemnikNominalow[i].SLWartosc;
                    //SLdgvListaNominalow.Rows[i].Cells[3].Value = SLcmbRodzajWaluty.SelectedItem.ToString();
                    if (SLPojemnikNominalow[i].SLWartosc >= SLBanknotOnajniszejWartosci)
                    {
                        SLdgvListaNominalow.Rows[i].Cells[2].Value = "banknot";
                    }
                    else
                    {
                        SLdgvListaNominalow.Rows[i].Cells[2].Value = "moneta";
                    }
                    //wycentrowanie zapisow w poszczegolnych komorkach i-trgo wiersza
                    for (ushort k = 0; k < 4; k++)
                        SLdgvListaNominalow.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //uaktywnienie kontrolek do wprowadzenia kwoty do wyplaty
                    SLlblPodajWysokoscKwoty.Enabled = true;
                    SLtxtKwotaDoWyplaty.Enabled = true;
                    SLbtnPrzyciskAkceptacjiNominalow.Enabled = true;
                    //
                    SLbtnAkceptacjaLicznosci.Enabled = false;
                    SLtxtWyplacanaKwota.Text = SLtxtKwotaDoWyplaty.Text;
                }
            }
            else
            {
                //przedzialowe ustalenie licznosci nominalow
                if (SLKontrolkiDodaneDoFormularza)
                {
                    SLbtnPrzyciskAkceptacjiNominalow.Enabled = true;
                    SLbtnPrzyciskAkceptacjiNominalow.Visible = true;
                    lblEtiketkaDolnejGranicaPrzedzialu.Visible = true;
                    lblEtiketkaGorneyGranicaPrzedzialu.Visible = true;
                    txtDolnaGranicaPrzedzialu.Visible = true;
                    txtDolnaGranicaPrzedzialu.Enabled = true;
                    txtDolnaGranicaPrzedzialu.Visible = true;
                    txtDolnaGranicaPrzedzialu.Enabled = true;
                    btnPrzycziskAkceptacjaNominalow.Enabled = true;
                    btnPrzycziskAkceptacjaNominalow.Visible = true;


                }
                else
                {
                    SLKontrolkiDodaneDoFormularza = true;
                    lblEtiketkaDolnejGranicaPrzedzialu.Text = "Dolna granica przedzialu liczności";
                    lblEtiketkaDolnejGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
                    lblEtiketkaDolnejGranicaPrzedzialu.TextAlign = ContentAlignment.MiddleCenter;
                    lblEtiketkaDolnejGranicaPrzedzialu.Visible = true;
                    //ustalenie lokalizacji i rozmiarów
                    lblEtiketkaDolnejGranicaPrzedzialu.Location = new Point(SLcmbRodzajWaluty.Left + SLcmbRodzajWaluty.Width,
                        groupBox1.Top + groupBox1.Height);
                    lblEtiketkaDolnejGranicaPrzedzialu.Height = 60;
                    lblEtiketkaDolnejGranicaPrzedzialu.Width = 150;
                    lblEtiketkaDolnejGranicaPrzedzialu.ForeColor = SLZakladki.TabPages[1].ForeColor;
                    lblEtiketkaDolnejGranicaPrzedzialu.BackColor = SLZakladki.TabPages[1].BackColor;
                    SLZakladki.TabPages[1].Controls.Add(lblEtiketkaDolnejGranicaPrzedzialu);
                    txtDolnaGranicaPrzedzialu.BackColor = Color.White;
                    txtDolnaGranicaPrzedzialu.ForeColor = Color.Black;
                    txtDolnaGranicaPrzedzialu.Visible = true;
                    txtDolnaGranicaPrzedzialu.Enabled = true;
                    txtDolnaGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                    txtDolnaGranicaPrzedzialu.Text = "";
                    txtDolnaGranicaPrzedzialu.TextAlign = HorizontalAlignment.Center;
                    txtDolnaGranicaPrzedzialu.Location = new Point(lblEtiketkaDolnejGranicaPrzedzialu.Left + lblEtiketkaDolnejGranicaPrzedzialu.Width, lblEtiketkaDolnejGranicaPrzedzialu.Top);
                    txtDolnaGranicaPrzedzialu.Size = new Size(50, 70);
                    txtDolnaGranicaPrzedzialu.BorderStyle = BorderStyle.FixedSingle;
                    SLZakladki.TabPages[1].Controls.Add(txtDolnaGranicaPrzedzialu);
                    lblEtiketkaGorneyGranicaPrzedzialu.Text = "Górna granica przedziału liczności";
                    lblEtiketkaGorneyGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic);
                    lblEtiketkaGorneyGranicaPrzedzialu.TextAlign = ContentAlignment.MiddleCenter;
                    lblEtiketkaGorneyGranicaPrzedzialu.Visible = true;
                    //ustalenie lokalizacji i rozmiarów
                    lblEtiketkaGorneyGranicaPrzedzialu.Location = new Point(txtDolnaGranicaPrzedzialu.Left + txtDolnaGranicaPrzedzialu.Width,
                       txtDolnaGranicaPrzedzialu.Top);
                    lblEtiketkaGorneyGranicaPrzedzialu.Height = 60;
                    lblEtiketkaGorneyGranicaPrzedzialu.Width = 150;
                    lblEtiketkaGorneyGranicaPrzedzialu.ForeColor = SLZakladki.TabPages[1].ForeColor;
                    lblEtiketkaGorneyGranicaPrzedzialu.BackColor = SLZakladki.TabPages[1].BackColor;
                    lblEtiketkaGorneyGranicaPrzedzialu.Visible = true;
                    SLZakladki.TabPages[1].Controls.Add(lblEtiketkaGorneyGranicaPrzedzialu);
                    txtGornaGranicaPrzdizualu.BackColor = Color.White;
                    txtGornaGranicaPrzdizualu.ForeColor = Color.Black;
                    txtGornaGranicaPrzdizualu.Visible = true;
                    txtGornaGranicaPrzdizualu.Enabled = true;
                    txtGornaGranicaPrzdizualu.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                    txtGornaGranicaPrzdizualu.Text = "";
                    txtGornaGranicaPrzdizualu.TextAlign = HorizontalAlignment.Center;
                    txtGornaGranicaPrzdizualu.Location = new Point(lblEtiketkaGorneyGranicaPrzedzialu.Left + lblEtiketkaGorneyGranicaPrzedzialu.Width, lblEtiketkaGorneyGranicaPrzedzialu.Top);
                    txtGornaGranicaPrzdizualu.Size = new Size(50, 30);
                    txtGornaGranicaPrzdizualu.BorderStyle = BorderStyle.FixedSingle;
                    SLZakladki.TabPages[1].Controls.Add(txtGornaGranicaPrzdizualu);
                    btnPrzycziskAkceptacjaNominalow.Text = "Akceptacja pzedziału liczności nominałów";
                    btnPrzycziskAkceptacjaNominalow.BackColor = this.BackColor;
                    btnPrzycziskAkceptacjaNominalow.ForeColor = Color.Black;
                    btnPrzycziskAkceptacjaNominalow.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                    btnPrzycziskAkceptacjaNominalow.Location = new Point(txtGornaGranicaPrzdizualu.Left + txtGornaGranicaPrzdizualu.Width, txtGornaGranicaPrzdizualu.Top);
                    btnPrzycziskAkceptacjaNominalow.Size = new Size(170, 60);
                    btnPrzycziskAkceptacjaNominalow.TextAlign = ContentAlignment.MiddleCenter;
                    btnPrzycziskAkceptacjaNominalow.Visible = true;
                    btnPrzycziskAkceptacjaNominalow.Enabled = true;
                    SLZakladki.TabPages[1].Controls.Add(btnPrzycziskAkceptacjaNominalow);
                    btnPrzycziskAkceptacjaNominalow.Click += new EventHandler(SLbtnPrzyciskAkceptacjiNominalow_Click);
                    SLlblPodajWysokoscKwoty.Enabled = true;
                    SLtxtKwotaDoWyplaty.Enabled = true;
                    SLbtnPrzyciskAkceptacjiNominalow.Enabled = true;

                }
            }
        }

        private void SLbtnPrzyciskAkceptacjiNominalow_Click(object sender, EventArgs e)
        {
            ushort DolnaGranica, GornaGranica;

            ErrorProvider1.Dispose();

            if (string.IsNullOrEmpty(txtDolnaGranicaPrzedzialu.Text))
            {
                ErrorProvider1.SetError(txtDolnaGranicaPrzedzialu,
                    "ERROR: musisz podać dolną granicę przedziału liczności nominałów!");
                return;
            }
            while (!ushort.TryParse(txtDolnaGranicaPrzedzialu.Text, out DolnaGranica))
            {
                ErrorProvider1.SetError(txtDolnaGranicaPrzedzialu,
                    "ERROR: błąd w zapisie dolnej granicy przedziału liczności nominałów!");
                return;
            }
            if (DolnaGranica <= 0)
            {
                ErrorProvider1.SetError(txtDolnaGranicaPrzedzialu,
                    "ERROR: dolna granica przedziału liczności nominałów musi być > 0!");
                return;
            }


            if (string.IsNullOrEmpty(txtGornaGranicaPrzdizualu.Text))
            {
                ErrorProvider1.SetError(txtGornaGranicaPrzdizualu,
                    "ERROR: musisz podać górną granicę przedziału liczności nominałów!");
                return;
            }
            while (!ushort.TryParse(txtGornaGranicaPrzdizualu.Text, out GornaGranica))
            {
                ErrorProvider1.SetError(txtGornaGranicaPrzdizualu,
                    "ERROR: błąd w zapisie górnej granicy przedziału liczności nominałów!");
                return;
            }
            if (GornaGranica <= DolnaGranica)
            {
                ErrorProvider1.SetError(txtGornaGranicaPrzdizualu,
                    "ERROR: górna granica przedziału liczności nominałów musi być spełniać" +
                    "warunek wejściowy: GórnaGranica > DolnaGranica");
                return;
            }

            Random Rnd = new Random();

            for (int k = 0; k < SLPojemnikNominalow.GetLength(0); k++)
            {
                SLPojemnikNominalow[k].SLLicznosc = (ushort)(Rnd.NextDouble() *
                    (GornaGranica - DolnaGranica) + DolnaGranica);
                SLPojemnikNominalow[k].SLWartosc = SLWartoscNominalow[k];
            }

            SLdgvListaNominalow.Visible = true;
            SLlblWyplaconeNominaly.Text = "Wylosowane nominały BANKOMATu";

            for (int i = 0; i < SLPojemnikNominalow.GetLength(0); i++)
            {
                SLdgvListaNominalow.Rows.Add();
                SLdgvListaNominalow.Rows[i].Cells[0].Value = SLPojemnikNominalow[i].SLLicznosc;
                SLdgvListaNominalow.Rows[i].Cells[1].Value = SLPojemnikNominalow[i].SLWartosc;
                if (SLPojemnikNominalow[i].SLWartosc >= SLBanknotOnajniszejWartosci)
                {
                    SLdgvListaNominalow.Rows[i].Cells[2].Value = "banknot";
                }
                else
                {
                    SLdgvListaNominalow.Rows[i].Cells[2].Value = "moneta";
                    SLdgvListaNominalow.Rows[i].Cells[3].Value = SLcmbRodzajWaluty.SelectedItem;
                }
                SLdgvListaNominalow.Rows[i].Cells[0].Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                SLdgvListaNominalow.Rows[i].Cells[1].Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                SLdgvListaNominalow.Rows[i].Cells[2].Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                SLdgvListaNominalow.Rows[i].Cells[3].Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            txtDolnaGranicaPrzedzialu.Enabled = false;
            txtGornaGranicaPrzdizualu.Enabled = false;
            SLcmbRodzajWaluty.Enabled = false;
            SLbtnPrzyciskAkceptacjiNominalow.Enabled = false;
            SLlblWyplaconeNominaly.Visible = true;
            SLdgvListaNominalow.Visible = true;
            SLlblPonownaWyplata.Visible = true;
        }

        private void SLbtnResetuj_Click(object sender, EventArgs e)
        {
            SLdgvListaNominalow.Visible = false;
            SLtxtKwotaDoWyplaty.Text = "";
            SLbtnAkceptacjaLicznosci.Enabled = true;
            SLtxtWyplacanaKwota.Text = "";
            SLcmbRodzajWaluty.Enabled = true;
            txtDolnaGranicaPrzedzialu.Enabled = true;
            txtGornaGranicaPrzdizualu.Enabled = true;

            SLlblWyplaconeNominaly.Visible = false;
            SLdgvListaNominalow.Visible = false;
            SLlblPonownaWyplata.Visible = false;
        }

        private void SLbtnKoniec_Click(object sender, EventArgs e)
        {
            DialogResult SLPytanie_Do_Użytkownika_Aplikacji =
          MessageBox.Show("Czy Pan chze zamkąć formularż ?",
                  Text,
         MessageBoxButtons.YesNoCancel,
         MessageBoxIcon.Question,
         MessageBoxDefaultButton.Button3);
            switch (SLPytanie_Do_Użytkownika_Aplikacji)
            {
                case DialogResult.Yes:
                    MessageBox.Show("Teraz nastąpił zamknięcia formularza " + this.Text);
                    Application.ExitThread();
                    break;
            }
        }
        // przypiszemy napojów zmienny i cenę
        double SLcoca = 3.75;
        double SLpepper = 4.00;
        double SLfanta = 3.00;
        double SLpepsi = 3.50;

        // przypiszemy batonów zmienny i cenę
        double SLkitkat = 4.00;
        double SLlion = 3.75;
        double SLmilka = 2.75;
        double SLskittles = 4.20;
        //Zadeklarujemy zmienną wrzuciony kwoty
        double SLKwota = 0.00;
        //Zadeklarujemy zmienną reszta
        double SLreszta = 0.00;
        // Jaki produkt wybrał klient
        string SLprodukt = "";
        // Zmiana ceny towarów w stosunku do wybranej waluty
        private void SLcmbWaluta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SLcmbWaluta.SelectedIndex == 1)
            {
                // przypiszemy napojów zmienny i cenę
                SLcoca = 1.75;
                SLpepper = 1.25;
                SLfanta = 0.90;
                SLpepsi = 1.10;

                // przypiszemy batonów zmienny i cenę
                SLkitkat = 2.00;
                SLlion = 1.75;
                SLmilka = 1.75;
                SLskittles = 1.20;
            }
            if (SLcmbWaluta.SelectedIndex == 2)
            {
                // przypiszemy napojów zmienny i cenę
                SLcoca = 1.35;
                SLpepper = 1.00;
                SLfanta = 0.60;
                SLpepsi = 1.00;

                // przypiszemy batonów zmienny i cenę
                SLkitkat = 1.50;
                SLlion = 1.35;
                SLmilka = 1.34;
                SLskittles = 0.90;
            }
            if (SLcmbWaluta.SelectedIndex == 3)
            {
                // przypiszemy napojów zmienny i cenę
                SLcoca = 1.55;
                SLpepper = 1.10;
                SLfanta = 0.80;
                SLpepsi = 1.00;

                // przypiszemy batonów zmienny i cenę
                SLkitkat = 1.80;
                SLlion = 1.55;
                SLmilka = 1.50;
                SLskittles = 1.00;
            }
        }

        private void SLbtnCoca_Click(object sender, EventArgs e)
        {
            SLtxtKwota.Text = SLcoca.ToString("0.00");
            SLprodukt = "napój CocaCola";
        }

        private void SLbtnPepper_Click(object sender, EventArgs e)
        {
            SLprodukt = "napój DrPepper";
            SLtxtKwota.Text = SLpepper.ToString("0.00");

        }

        private void SLbtnPepsi_Click(object sender, EventArgs e)
        {
            SLprodukt = "napój Pepsi";
            SLtxtKwota.Text = SLpepsi.ToString("0.00");
        }

        private void SLbtnFanta_Click(object sender, EventArgs e)
        {
            SLprodukt = "napój Fanta";
            SLtxtKwota.Text = SLfanta.ToString("0.00");
        }

        private void SLbtnKitkat_Click(object sender, EventArgs e)
        {
            SLprodukt = "baton KitKat";
            SLtxtKwota.Text = SLkitkat.ToString("0.00");
        }

        private void SLbtnLion_Click(object sender, EventArgs e)
        {
            SLprodukt = "baton Lion";
            SLtxtKwota.Text = SLlion.ToString("0.00");
        }

        private void SLbtnMilka_Click(object sender, EventArgs e)
        {
            SLprodukt = "baton Milka";
            SLtxtKwota.Text = SLmilka.ToString("0.00");
        }

        private void SLbtnSkittles_Click(object sender, EventArgs e)
        {
            SLprodukt = "baton Skittles";
            SLtxtKwota.Text = SLskittles.ToString("0.00");
        }

        private void SLbtn050Moneta_Click(object sender, EventArgs e)
        {
            SLKwota += 0.50;
            SLtxtIloscPiendzy.Text = SLKwota.ToString();
        }

        private void SLbtn1Moneta_Click(object sender, EventArgs e)
        {
            SLKwota += 1.00;
            SLtxtIloscPiendzy.Text = SLKwota.ToString();
        }

        private void SLbtn2Moneta_Click(object sender, EventArgs e)
        {
            SLKwota += 2.00;
            SLtxtIloscPiendzy.Text = SLKwota.ToString();
        }

        private void SLbtn5Moneta_Click(object sender, EventArgs e)
        {
            SLKwota += 5.00;
            SLtxtIloscPiendzy.Text = SLKwota.ToString();
        }

        private void SLbtnZaplacMonetami_Click(object sender, EventArgs e)
        {
            
            double SLKwota, SLiloscPiendzy;
            ErrorProvider1.Dispose();
            if (SLprodukt != "")
            {
              SLbtnCoca.Enabled = false;
              SLbtnPepper.Enabled = false;
              SLbtnPepsi.Enabled = false;
              SLbtnFanta.Enabled = false;
              SLbtnKitkat.Enabled = false;
              SLbtnLion.Enabled = false;
              SLbtnMilka.Enabled = false;
              SLbtnSkittles.Enabled = false;
              SLcmbWaluta.Enabled = false;
            }

            if (string.IsNullOrEmpty(SLprodukt))
            {
                ErrorProvider1.SetError(SLbtnZaplacMonetami,
                    "ERROR: Wyberz produkt");
                return;
            }
            while (!double.TryParse(SLtxtKwota.Text, out SLKwota))
            {
                ErrorProvider1.SetError(SLbtnZaplacMonetami,
                    "ERROR: Nie poprawnie wartość");
                return;
            }

            while (!double.TryParse(SLtxtIloscPiendzy.Text, out SLiloscPiendzy))
            {
                ErrorProvider1.SetError(SLbtnZaplacMonetami,
                    "ERROR: Nie wrzuciłeś monety");
                return;
            }
            if (SLKwota > SLiloscPiendzy)
            {
                ErrorProvider1.SetError(SLbtnZaplacMonetami,
                    "ERROR: Kwota do zapłaty jest więcej niż wrzucony monety");
                return;
            }
            if (SLrodzajWaluty.SelectedIndex == 1)
            {
                ErrorProvider1.SetError(SLbtnZaplacMonetami,
                    "ERROR: Musisz najpierw wybrać płatność monetami");
                return;
            }
            else
            {
                SLreszta = (double.Parse(SLtxtIloscPiendzy.Text) - double.Parse(SLtxtKwota.Text));
                SLtxtreszta.Text = SLreszta.ToString("0.00");

                SLlblKupno.Visible = true;
                SLlblKupno.Text = $"Gratulacje! Kupiliście {SLprodukt}, twoja reszta: {SLreszta}.\r\n\t Miłego dnia !";
            }
        }

        private void SLpowrotDoPulpit2_Click(object sender, EventArgs e)
        {
            /* ustawienie braku zezwolenia na przejście do strony Bankomat,
               gdyż ma nastąpić przejście do strony Pulpit */
            SLStanStronZakladki[1] = false;
            // zezwolenie na przejście do strony Bankomat
            SLStanStronZakladki[0] = true;
            // realizacja przejście do strony Bankomat
            SLZakladki.SelectedTab = SLtabPagePulpit;
            // lub : Zakladki.TabIndex = 0;
        }

        private void SLbtnZaplacKarta_Click(object sender, EventArgs e)
        {
            
            double SLKwota;
            ErrorProvider1.Dispose();
            if (string.IsNullOrEmpty(SLprodukt))
            {
                ErrorProvider1.SetError(SLbtnZaplacKarta,
                    "ERROR: Wyberz produkt");
                return;
            }
            while (!double.TryParse(SLtxtKwota.Text, out SLKwota))
            {
                ErrorProvider1.SetError(SLbtnZaplacKarta,
                    "ERROR: Nie poprawnie wartość");
                return;
            }

            if (SLrodzajWaluty.SelectedIndex == 0)
            {
                ErrorProvider1.SetError(SLbtnZaplacKarta,
                    "ERROR: Musisz najpierw wybrać płatność kartą");
                return;
            }
            else
            {
                SLlblKupno.Visible = true;
                SLlblKupno.Text = $"Gratulacje! Kupiliście {SLprodukt}.\r\n\t Miłego dnia !";
            }
        }

        private void SLbtnResetMV_Click(object sender, EventArgs e)
        {
            SLbtnCoca.Enabled = true;
            SLbtnPepper.Enabled = true;
            SLbtnPepsi.Enabled = true;
            SLbtnFanta.Enabled = true;
            SLbtnKitkat.Enabled = true;
            SLbtnLion.Enabled = true;
            SLbtnMilka.Enabled = true;
            SLbtnSkittles.Enabled = true;
            SLcmbWaluta.Enabled = true;
            SLrodzajWaluty.SelectedIndex = 0;
            SLcmbWaluta.SelectedIndex = 0;
            SLtxtKwota.Text = "0.00";
            SLtxtIloscPiendzy.Text = "0.00";
            SLtxtreszta.Text = "0.00";
            SLprodukt = "";
            SLlblKupno.Visible = false;
            SLKwota = 0.00;
            SLreszta = 0.00;
        }
    }


}
