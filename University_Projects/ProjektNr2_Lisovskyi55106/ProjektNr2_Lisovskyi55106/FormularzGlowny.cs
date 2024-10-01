using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr2_Lisovskyi55106
{
    public partial class FormularzGlowny : Form
    {
        public FormularzGlowny()
        {
            InitializeComponent();
        }

        private void SLbtnLaboratorium_Click(object sender, EventArgs e)
        {
            //odszukanie egzemplarza formularza w kolekcji OpenForms aplikacji
            foreach (Form FormLab in Application.OpenForms)
            {
                if (FormLab.Name == "Laboratorium")
                {
                    //ukrycie biezacego formularzu
                    this.Hide();
                    //odsloniecie znalezionego formularza
                    FormLab.Show();
                    return;
                }
            }
            //utworzenie formularza do ktorego chcemy przejsc
            Laboratorium FormLaboratorium = new Laboratorium();
            //ukrycie biezacego formularza
            this.Hide();
            //odsloniecie formularza formlab
            FormLaboratorium.Show();
        }

        private void SLbtnProjekt_Click(object sender, EventArgs e)
        {
            //odszukanie egzemplarza formularza w kolekcji OpenForms aplikacji
            foreach (Form FormLab in Application.OpenForms)
            {
                if (FormLab.Name == "SLProjekt2")
                {
                    //ukrycie biezacego formularzu
                    this.Hide();
                    //odsloniecie znalezionego formularza
                    FormLab.Show();
                    return;
                }
            }
            //utworzenie formularza do ktorego chcemy przejsc
            SLProjekt2 FormProjekt = new SLProjekt2();
            //ukrycie biezacego formularza
            this.Hide();
            //odsloniecie formularza formlab
            FormProjekt.Show();
        }
    }
}
