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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjektNr2_Lisovskyi55106
{
    public partial class SLProjekt2 : Form
    {
        const int SLMargines = 20;
        //deklaracja zmiennych
        int SLMinProbaBadawcza;
        int SLMaxRozmiarTablic;
        double SLDolnaGranica;
        double SLGornaGranica;

        //deklarcja tablic
        double[] SLTablicaDoSortowania;
        double[] SLTablicaPrzedSortowaniem;
        float[] SLWynikiZpomiaru;
        float[] SLWynikiAnalityczne;
        int[] SLWynikiKosztuPamięci;
        int[] SLTablicaLOD;
        public SLProjekt2()
        {
            InitializeComponent();
            
        }

        private void SLbtnPowrot_Click(object sender, EventArgs e)
        {
            //odszukanie egzemplarza formularza glownego w kolekcji OpenForms aplikacji
            foreach (Form FormGlowny in Application.OpenForms)
            {
                if (FormGlowny.Name == "FormularzGlowny")
                {
                    //ukrycie biezacego formularzu
                    this.Hide();
                    //odsloniecie znalezionego formularza
                    FormGlowny.Show();
                    return;
                }
            }
            FormularzGlowny pulpit = new FormularzGlowny();
            this.Hide();
            pulpit.Show();
        }
        

        private void SLbtntabelarycznaWizualizacja_Click(object sender, EventArgs e)
        {
            SLdgvTabelaWyników.Rows.Clear();
            //Tabela
            for (int i = 0; i < SLMaxRozmiarTablic; i++)
            {
                SLdgvTabelaWyników.Rows.Add();
                SLdgvTabelaWyników.Rows[i].Cells[0].Value = i + 1;
                SLdgvTabelaWyników.Rows[i].Cells[1].Value = String.Format("{0:F2}", SLWynikiZpomiaru[i]);
                SLdgvTabelaWyników.Rows[i].Cells[2].Value = String.Format("{0:F2}", SLWynikiAnalityczne[i]);
                SLdgvTabelaWyników.Rows[i].Cells[3].Value = SLWynikiKosztuPamięci[i];

                if (i % 2 == 0)
                {
                    SLdgvTabelaWyników.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
                    SLdgvTabelaWyników.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                    SLdgvTabelaWyników.Rows[i].Cells[2].Style.BackColor = Color.LightGray;
                    SLdgvTabelaWyników.Rows[i].Cells[3].Style.BackColor = Color.LightGray;
                }
                else
                {
                    SLdgvTabelaWyników.Rows[i].Cells[0].Style.BackColor = Color.White;
                    SLdgvTabelaWyników.Rows[i].Cells[1].Style.BackColor = Color.White;
                    SLdgvTabelaWyników.Rows[i].Cells[2].Style.BackColor = Color.White;
                    SLdgvTabelaWyników.Rows[i].Cells[3].Style.BackColor = Color.White;
                }

                SLdgvTabelaWyników.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                SLdgvTabelaWyników.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                SLdgvTabelaWyników.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                SLdgvTabelaWyników.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            SLdgvTabelaWyników.Visible = true;
            SLdgvElementyTablicy.Visible = false;
            SLdgvDemo.Visible = false;
            SLchartWykres.Visible = false;
            SLbtntabelarycznaWizualizacja.Enabled = false;
        }

        private void SLgraficznaWizualizacja_Click(object sender, EventArgs e)
        {
            SLdgvElementyTablicy.Visible = false;
            SLdgvDemo.Visible = false;
            SLdgvTabelaWyników.Visible = false;
            SLchartWykres.Visible = true;

            SLchartWykres.Titles.Clear();
            SLchartWykres.Titles.Add("Algorytm " + SLcmbAlgorytmSort.SelectedItem);
            SLchartWykres.Legends["Legend1"].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;

            int[] SLRozmiarTabeli = new int[SLMaxRozmiarTablic];
            for (int i = 0; i < SLMaxRozmiarTablic; i++)
                SLRozmiarTabeli[i] = i;

            SLchartWykres.Series[0].Name = "Koszt czasowy z pomiaru";
            SLchartWykres.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SLchartWykres.Series[0].Color = Color.Red;
            SLchartWykres.Series[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            SLchartWykres.Series[0].BorderWidth = 2;
            SLchartWykres.Series[0].Points.DataBindXY(SLRozmiarTabeli, SLWynikiZpomiaru);

            SLchartWykres.Series[1].Name = "Koszt czasowy wg. wzoru";
            SLchartWykres.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SLchartWykres.Series[1].Color = Color.Orange;
            SLchartWykres.Series[1].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            SLchartWykres.Series[1].BorderWidth = 2;
            SLchartWykres.Series[1].Points.DataBindXY(SLRozmiarTabeli, SLWynikiAnalityczne);

            SLchartWykres.Series[2].Name = "Koszt pamięciowy";
            SLchartWykres.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SLchartWykres.Series[2].Color = Color.Yellow;
            SLchartWykres.Series[2].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            SLchartWykres.Series[2].BorderWidth = 2;
            SLchartWykres.Series[2].Points.DataBindXY(SLRozmiarTabeli, SLWynikiKosztuPamięci);

            SLgraficznaWizualizacja.Enabled = false;
            SLbtnWybierzKolorLinii.Visible = true;
            SLbtnWybierzKolorTla.Visible = true;
            SLlblWziernikKoloruLinii.Visible = true;
            SLlblStylLinii.Visible = true;
            SLlblWziernikKoloruTla.Visible = true;
            SLpbKolorLinii.Visible = true;
            SLpbKolorTla.Visible = true;
            SLtxtGruboscLinii.Visible = true;
            SLtxtGruboscLinii.Visible = true;
            SLtbGruboscLinii.Visible = true;
            SLlblGrubosc.Visible = true;
            SLlblGruboscLiczbowo.Visible = true;
            SLcmbStylLinii.Visible = true;
            SLcmbTypWykresu.Visible = true;
            SLlblTypWykresu.Visible = true;
        }

        private void SLbtnAkceptacjaDanych_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(SLtxtMinPróbaBadawcza.Text, out SLMinProbaBadawcza))
            {
                SLerrorProvider1.SetError(SLtxtMinPróbaBadawcza, "Wprowadź minimalną próbę badawczą.");
                return;
            }
            if (!int.TryParse(SLtxtMaxRozmiarTablic.Text, out SLMaxRozmiarTablic))
            {
                SLerrorProvider1.SetError(SLtxtMaxRozmiarTablic, "Wprowadź maksymalny rozmiar tablicy.");
                return;
            }
            if (!double.TryParse(SLtxtDolnaGranica.Text, out SLDolnaGranica))
            {
                SLerrorProvider1.SetError(SLtxtDolnaGranica, "Wprowadź dolną granice elementu.");
                return;
            }
            if (!double.TryParse(SLtxtGornaGranica.Text, out SLGornaGranica))
            {
                SLerrorProvider1.SetError(SLtxtGornaGranica, "Wprowadź górną granicę elementu.");
                return;
            }
            if (SLcmbAlgorytmSort.Text == "")
            {
                SLerrorProvider1.SetError(SLcmbAlgorytmSort, "ERROR: musisz wybrać jeden z podanych algorytmów sortowania");
                return;
            }
            SLerrorProvider1.Dispose();

            SLTablicaDoSortowania = new double[SLMaxRozmiarTablic];
            SLTablicaPrzedSortowaniem = new double[SLMaxRozmiarTablic];
            SLWynikiZpomiaru = new float[SLMaxRozmiarTablic];
            SLWynikiAnalityczne = new float[SLMaxRozmiarTablic];
            SLWynikiKosztuPamięci = new int[SLMaxRozmiarTablic];
            SLTablicaLOD = new int[SLMinProbaBadawcza];

            SLbtnPoSortowaniu.Visible = true;
            SLbtnResetuj.Visible = true;
            SLbtntabelarycznaWizualizacja.Visible = true;
            SLgraficznaWizualizacja.Visible = true;
            SLbtnDEMO.Visible = true;
            SLbtnPoSortowaniu.Enabled = true;
            SLbtnResetuj.Enabled = true;
        }

        private void SLbtnWybierzKolorLinii_Click(object sender, EventArgs e)
        {
            if (SLcolorDialog1.ShowDialog() == DialogResult.OK)
            {
                SLpbKolorLinii.BackColor = SLcolorDialog1.Color;
                SLchartWykres.Series[0].Color = SLcolorDialog1.Color;
                SLchartWykres.Series[1].Color = SLcolorDialog1.Color;
                SLchartWykres.Series[2].Color = SLcolorDialog1.Color;
            }
        }

        private void SLbtnWybierzKolorTla_Click(object sender, EventArgs e)
        {
            if (SLcolorDialog1.ShowDialog() == DialogResult.OK)
            {
                SLpbKolorTla.BackColor = SLcolorDialog1.Color;
                SLchartWykres.ChartAreas["ChartArea1"].BackColor = SLcolorDialog1.Color;
            }
        }

        private void SLtbGruboscLinii_Scroll(object sender, EventArgs e)
        {
            SLtxtGruboscLinii.Text = Convert.ToString(SLtbGruboscLinii.Value);
            SLchartWykres.Series[0].BorderWidth = SLtbGruboscLinii.Value;
            SLchartWykres.Series[1].BorderWidth = SLtbGruboscLinii.Value;
            SLchartWykres.Series[2].BorderWidth = SLtbGruboscLinii.Value;
        }

        private void SLcmbStylLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SLcmbStylLinii.Text == "Ciągła (Solid)")
            {
                SLchartWykres.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                SLchartWykres.Series[1].BorderDashStyle = ChartDashStyle.Solid;
                SLchartWykres.Series[2].BorderDashStyle = ChartDashStyle.Solid;
            }
            else if (SLcmbStylLinii.Text == "Kropkowa")
            {
                SLchartWykres.Series[0].BorderDashStyle = ChartDashStyle.Dot;
                SLchartWykres.Series[1].BorderDashStyle = ChartDashStyle.Dot;
                SLchartWykres.Series[2].BorderDashStyle = ChartDashStyle.Dot;
            }
            else if (SLcmbStylLinii.Text == "Kreskowa")
            {
                SLchartWykres.Series[0].BorderDashStyle = ChartDashStyle.Dash;
                SLchartWykres.Series[1].BorderDashStyle = ChartDashStyle.Dash;
                SLchartWykres.Series[2].BorderDashStyle = ChartDashStyle.Dash;
            }
            else if (SLcmbStylLinii.Text == "Kreskowo-Kropkowa")
            {
                SLchartWykres.Series[0].BorderDashStyle = ChartDashStyle.DashDot;
                SLchartWykres.Series[1].BorderDashStyle = ChartDashStyle.DashDot;
                SLchartWykres.Series[2].BorderDashStyle = ChartDashStyle.DashDot;
            }
        }

        private void SLbtnResetuj_Click(object sender, EventArgs e)
        {
            SLbtnWybierzKolorLinii.Visible = false;
            SLbtnWybierzKolorTla.Visible = false;
            SLlblWziernikKoloruLinii.Visible = false;
            SLlblStylLinii.Visible = false;
            SLlblWziernikKoloruTla.Visible = false;
            SLpbKolorLinii.Visible = false;
            SLpbKolorTla.Visible = false;
            SLtxtGruboscLinii.Visible = false;
            SLcmbStylLinii.Visible = false;
            SLtbGruboscLinii.Visible = false;
            SLlblGruboscLiczbowo.Visible = false;
            SLlblGrubosc.Visible = false;
            SLgraficznaWizualizacja.Enabled = true;
            SLgraficznaWizualizacja.Visible = false;
            SLbtntabelarycznaWizualizacja.Enabled = true;
            SLbtntabelarycznaWizualizacja.Visible = false;
            SLbtnResetuj.Visible = false;
            SLbtnAkceptacjaDanych.Visible = true;
            SLbtnAkceptacjaDanych.Enabled = true;
            SLcmbAlgorytmSort.Enabled = true;
            SLtxtMinPróbaBadawcza.Enabled = true;
            SLtxtMaxRozmiarTablic.Enabled = true;
            SLtxtGornaGranica.Enabled = true;
            SLtxtDolnaGranica.Enabled = true;
            SLcmbAlgorytmSort.Text = "";
            SLdgvTabelaWyników.Visible = false;
            SLchartWykres.Visible = false;
            SLdgvDemo.Visible = false;
            SLbtnDEMO.Visible = false;
            SLbtnPoSortowaniu.Visible = false;
            SLcmbTypWykresu.Visible = false;
            SLlblTypWykresu.Visible = false;
            SLdgvElementyTablicy.Visible = false;
            SLbtntabelarycznaWizualizacja.Enabled = false;
            SLgraficznaWizualizacja.Enabled = false;
        }

        private void SLcmbTypWykresu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SLcmbTypWykresu.Text == "Liniowy")
            {
                SLchartWykres.Series[0].ChartType = SeriesChartType.Line;
            }
            else if (SLcmbTypWykresu.Text == "Kolumniowy")
            {
                SLchartWykres.Series[0].ChartType = SeriesChartType.Column;
            }
            else if (SLcmbTypWykresu.Text == "Słupkowy")
            {
                SLchartWykres.Series[0].ChartType = SeriesChartType.Column;
            }
        }

        private void SLbtnPoSortowaniu_Click(object sender, EventArgs e)
        {
            SLdgvElementyTablicy.Rows.Clear();

            int SLLicznikOD = 0;
            float SLSumaOD, SLŚredniaOD;
            Random SLRnd = new Random();

            for (int l = 1; l <= SLMaxRozmiarTablic; l++)
            {
                for (int k = 0; k < SLMinProbaBadawcza; k++)
                {
                    for (int i = 0; i < SLMaxRozmiarTablic; i++)
                        SLTablicaDoSortowania[i] = SLRnd.NextDouble() * (SLGornaGranica - SLDolnaGranica) + SLDolnaGranica;
                    Array.Copy(SLTablicaDoSortowania, SLTablicaPrzedSortowaniem, SLMaxRozmiarTablic);
                    switch (SLcmbAlgorytmSort.SelectedIndex)
                    {
                        case 0:
                            SLLicznikOD = SLSortowanie.SLSelectSort(ref SLTablicaDoSortowania, l);
                            break;
                        case 1:
                            SLLicznikOD = SLSortowanie.SLInsertionSort(ref SLTablicaDoSortowania, l);
                            break;
                        default:
                            SLerrorProvider1.SetError(SLbtntabelarycznaWizualizacja, "UWAGA: jeszcze nie ukończyłem prac nad tym algorytmem.");
                            return;
                    }
                    SLTablicaLOD[k] = SLLicznikOD;
                }
                SLSumaOD = 0.0f;
                for (int j = 0; j < SLMinProbaBadawcza; j++)
                    SLSumaOD += SLTablicaLOD[j];
                SLŚredniaOD = SLSumaOD / SLMinProbaBadawcza;
                SLWynikiZpomiaru[l - 1] = SLŚredniaOD;

                switch (SLcmbAlgorytmSort.SelectedIndex)
                {
                    case 0:
                        SLWynikiAnalityczne[l - 1] = (float)(l * (Math.Log(l) / Math.Log(2) + 1));
                        SLWynikiZpomiaru[l - 1] = (l * (l - 1)) / 2;
                        SLWynikiKosztuPamięci[l - 1] = l;
                        break;
                    case 1:
                        SLWynikiAnalityczne[l - 1] = (l * (l - 1)) / 2;
                        SLWynikiZpomiaru[l - 1] = (l * (l - 1)) / 2;
                        SLWynikiKosztuPamięci[l - 1] = l;
                        break;
                    default:
                        SLerrorProvider1.SetError(SLbtntabelarycznaWizualizacja, "UWAGA: jeszcze nie ukończyłem prac nad tym algorytmem!");
                        return;
                }
            }
            {            //wpisanie danych do DGV
                for (int i = 0; i < SLMaxRozmiarTablic; i++)
                {
                    SLdgvElementyTablicy.Rows.Add();
                    SLdgvElementyTablicy.Rows[i].Cells[0].Value = i;
                    SLdgvElementyTablicy.Rows[i].Cells[1].Value = String.Format("{0, 8:F3}", SLTablicaPrzedSortowaniem[i]);
                    SLdgvElementyTablicy.Rows[i].Cells[2].Value = String.Format("{0, 8:F3}", SLTablicaDoSortowania[i]);
                    if ((i % 2) == 0)
                    {
                        SLdgvElementyTablicy.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
                        SLdgvElementyTablicy.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                        SLdgvElementyTablicy.Rows[i].Cells[2].Style.BackColor = Color.LightGray;
                    }
                    else
                    {
                        SLdgvElementyTablicy.Rows[i].Cells[0].Style.BackColor = Color.White;
                        SLdgvElementyTablicy.Rows[i].Cells[1].Style.BackColor = Color.White;
                        SLdgvElementyTablicy.Rows[i].Cells[2].Style.BackColor = Color.White;
                    }
                    SLdgvElementyTablicy.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SLdgvElementyTablicy.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SLdgvElementyTablicy.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                SLdgvElementyTablicy.Visible = true;
                SLdgvDemo.Visible = false;
                SLdgvTabelaWyników.Visible = false;
                SLbtnPoSortowaniu.Enabled = false;
                SLbtntabelarycznaWizualizacja.Enabled = true;
                SLgraficznaWizualizacja.Enabled = true;
                SLbtnResetuj.Enabled = true;
                SLbtnDEMO.Enabled = true;

                MessageBox.Show("Przeprowadzono sortowanie algorytmem: " + SLcmbAlgorytmSort.SelectedItem);
            }
        }

        private void SLbtnDEMO_Click(object sender, EventArgs e)
        {
            SLdgvDemo.Rows.Clear();

            int SLLicznikOD = 0;
            float SLSumaOD, SLŚredniaOD;
            Random SLRnd = new Random();

            for (int l = 1; l <= SLMaxRozmiarTablic; l++)
            {
                for (int k = 0; k < SLMinProbaBadawcza; k++)
                {
                    for (int i = 0; i < SLMaxRozmiarTablic; i++)
                        SLTablicaDoSortowania[i] = SLRnd.NextDouble() * (SLGornaGranica - SLDolnaGranica) + SLDolnaGranica;
                    Array.Copy(SLTablicaDoSortowania, SLTablicaPrzedSortowaniem, SLMaxRozmiarTablic);
                    switch (SLcmbAlgorytmSort.SelectedIndex)
                    {
                        case 0:
                            SLLicznikOD = SLSortowanie.SLSelectSort(ref SLTablicaDoSortowania, l);
                            break;
                        case 1:
                            SLLicznikOD = SLSortowanie.SLInsertionSort(ref SLTablicaDoSortowania, l);
                            break;
                        default:
                            SLerrorProvider1.SetError(SLbtntabelarycznaWizualizacja, "UWAGA: jeszcze nie ukończyłem prac nad tym algorytmem.");
                            return;
                    }
                    SLTablicaLOD[k] = SLLicznikOD;
                }
                SLSumaOD = 0;
                for (int j = 0; j < SLMinProbaBadawcza; j++)
                    SLSumaOD += SLTablicaLOD[j];
                SLŚredniaOD = SLSumaOD / SLMinProbaBadawcza;
                SLWynikiZpomiaru[l - 1] = SLŚredniaOD;

                switch (SLcmbAlgorytmSort.SelectedIndex)
                {
                    case 0:
                        SLWynikiAnalityczne[l - 1] = (float)(l * (Math.Log(l) / Math.Log(2) + 1));
                        SLWynikiZpomiaru[l - 1] = (l * (l - 1)) / 2;
                        SLWynikiKosztuPamięci[l - 1] = l;
                        break;
                    case 1:
                        SLWynikiAnalityczne[l - 1] = (l);
                        SLWynikiZpomiaru[l - 1] = (l);
                        SLWynikiKosztuPamięci[l - 1] = l;
                        break;
                    default:
                        SLerrorProvider1.SetError(SLbtntabelarycznaWizualizacja, "UWAGA: jeszcze nie ukończyłem prac nad tym algorytmem!");
                        return;
                }
            }
            {            //wpisanie danych do DGV
                SLdgvTabelaWyników.Rows.Clear();
                //Tabela
                for (int i = 0; i < SLMaxRozmiarTablic; i++)
                {
                    SLdgvDemo.Rows.Add();
                    SLdgvDemo.Rows[i].Cells[0].Value = i;
                    SLdgvDemo.Rows[i].Cells[1].Value = String.Format("{0, 8:F3}", SLTablicaDoSortowania[i]);
                    if ((i % 2) == 0)
                    {
                        SLdgvDemo.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
                        SLdgvDemo.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                    }
                    else
                    {
                        SLdgvDemo.Rows[i].Cells[0].Style.BackColor = Color.White;
                        SLdgvDemo.Rows[i].Cells[1].Style.BackColor = Color.White;
                    }
                    SLdgvDemo.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SLdgvDemo.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                SLdgvElementyTablicy.Visible = false;
                SLdgvDemo.Visible = true;
                // MessageBox.Show("Przeprowadzono sortowanie algorytmem: " + obcmbAlgorytmDoAnalizy.SelectedItem);
            }
        }
    }
}
