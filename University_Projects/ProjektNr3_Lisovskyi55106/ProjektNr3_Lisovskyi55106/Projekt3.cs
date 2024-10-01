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
    public partial class Projekt3 : Form
    {
        int SLnumberOfVerteces;
        int SLnumberOfEdges;
        SLGraph SLgraph;
        ushort SLLicznik = 0;
        public Projekt3()
        {
            InitializeComponent();
        }

        private void SLProjekt3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SLbtnAkceptacja_Click_1(object sender, EventArgs e)
        {
            SLerrorProvider1.Dispose();
            if (!int.TryParse(SLtxtVenteces.Text, out SLnumberOfVerteces))
            {
                SLerrorProvider1.SetError(SLtxtVenteces, "ERROR: Nie podałeś liczby wierzchołków");
            }
            if (!int.TryParse(SLtxtEdges.Text, out SLnumberOfEdges))
            {
                SLerrorProvider1.SetError(SLtxtEdges, "ERROR: Nie podałeś liczby krawędzi");
            }
            SLgraph = new SLGraph(SLnumberOfVerteces);

            SLbtnAkceptacja.Enabled = false;
            SLbtnExampleList.Enabled = false;
            SLtxtVenteces.Enabled = false;
            SLtxtEdges.Enabled = false;
        }

        private void SLbtnWizualizacja_Click_1(object sender, EventArgs e)
        {
            SLrtbPrint.Text = "Wizualizacja grafu: \n";
            for (int i = 0; i < SLgraph.SLGetLength(); i++)
            {
                SLrtbPrint.Text += i + " -> ";
                foreach (int edge in SLgraph.SLadjancencyList[i])
                {
                    SLrtbPrint.Text += edge + " ";
                }
                SLrtbPrint.Text += "\n";
            }
            SLbtnWizualizacja.Enabled = false;
        }

        private void SLtxtVenteces_TextChanged(object sender, EventArgs e)
        {

        }

        private void SLbtnPowrot_Click_1(object sender, EventArgs e)
        {
            foreach (Form SLFormGlowny in Application.OpenForms)
            {
                if (SLFormGlowny.Name == "Pulpit")
                {
                    this.Hide();
                    SLFormGlowny.Show();
                    return;
                }
            }
            Pulpit SLpulpit = new Pulpit();
            this.Hide();
            SLpulpit.Show();
        }

        private void SLbtnDodaj_Click_1(object sender, EventArgs e)
        {
            SLerrorProvider1.Dispose();
            int SLVertexStart;
            int SLVertexEnd;
            if ((!int.TryParse(SLtxtVertexStart.Text, out SLVertexStart)) || (SLVertexStart >= SLnumberOfVerteces))
            {
                SLerrorProvider1.SetError(SLtxtVertexStart, "ERROR: Nie prawidłowo podałeś wierzchołku startu");
                return;
            }

            if ((!int.TryParse(SLtxtVertexEnd.Text, out SLVertexEnd)) || (SLVertexEnd >= SLnumberOfVerteces))
            {
                SLerrorProvider1.SetError(SLtxtVertexEnd, "ERROR: Nie prawidłowo podałeś wierzchołku końcu");
                return;
            }

            SLgraph.SLaddEdge(SLVertexStart, SLVertexEnd);
            SLLicznik++;
            if (SLLicznik == SLnumberOfEdges)
            {
                SLbtnDodaj.Enabled = false;
                SLtxtVertexStart.Enabled = false;
                SLtxtVertexEnd.Enabled = false;
            }
            SLtxtVertexStart.Text = "";
            SLtxtVertexEnd.Text = "";
        }

        private void SLbtnBFS_Click_1(object sender, EventArgs e)
        {
            SLerrorProvider1.Dispose();
            int SLStart;
            if ((!int.TryParse(SLtxtStart.Text, out SLStart)) || (SLStart >= SLgraph.SLGetLength()))
            {
                SLerrorProvider1.SetError(SLtxtStart, "ERROR: Nieprawidłowo podałeś wartość wierzchołku startu");
                return;
            }

            String s = "";

            SLrtbPrint.Text += "Wizualizacja algorytmu Depth-First Search: \n";
            s = SLgraph.SLBFS(SLStart);
            SLrtbPrint.Text += s;
            SLbtnBFS.Enabled = false;
            SLtxtStart.Enabled = false;
        }

        private void SLbtnExampleList_Click(object sender, EventArgs e)
        {
            SLgraph = new SLGraph(7);

            SLgraph.SLaddEdge(0, 2);
            SLgraph.SLaddEdge(0, 1);
            SLgraph.SLaddEdge(1, 3);
            SLgraph.SLaddEdge(2, 4);
            SLgraph.SLaddEdge(2, 5);
            SLgraph.SLaddEdge(4, 6);
            SLgraph.SLaddEdge(6, 4);
            SLgraph.SLaddEdge(4, 5);
            SLgraph.SLaddEdge(5, 4);


            SLtxtVenteces.Text = "7";
            SLtxtEdges.Text = "6";
            SLbtnExampleList.Enabled = false;
            SLtxtVenteces.Enabled = false;
            SLtxtEdges.Enabled = false;
            SLtxtVertexStart.Enabled = false;
            SLtxtVertexEnd.Enabled = false;
            SLbtnAkceptacja.Enabled = false;
            SLbtnDodaj.Enabled = false;
        }

        private void SLbtnClean_Click_1(object sender, EventArgs e)
        {
            SLLicznik = 0;
            SLtxtVenteces.Text = "";
            SLtxtEdges.Text = "";
            SLtxtVertexStart.Text = "";
            SLtxtVertexEnd.Text = "";
            SLtxtStart.Text = "";
            SLtxtVenteces.Enabled = true;
            SLtxtEdges.Enabled = true;
            SLbtnAkceptacja.Enabled = true;
            SLbtnDodaj.Enabled = true;
            SLbtnExampleList.Enabled = true;
            SLrtbPrint.Text = "";
            SLbtnWizualizacja.Enabled = true;
            SLbtnBFS.Enabled = true;
            SLtxtVertexStart.Enabled = true;
            SLtxtVertexEnd.Enabled = true;
            SLtxtStart.Enabled = true;
        }
    }
}
