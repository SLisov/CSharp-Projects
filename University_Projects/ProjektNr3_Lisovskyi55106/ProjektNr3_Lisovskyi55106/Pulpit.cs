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
    public partial class Pulpit : Form
    {
        public Pulpit()
        {
            InitializeComponent();
        }

        private void SLbtnLaboratorium_Click(object sender, EventArgs e)
        {

            foreach (Form FormLab in Application.OpenForms)
            {
                if (FormLab.Name == "Laboratorium")
                {
                    this.Hide();
                    FormLab.Show();
                    return;
                }
            }
            Laboratorium FormLaboratorium = new Laboratorium();
            this.Hide();
            FormLaboratorium.Show();
        }

        private void SLbtnProjekt3_Click(object sender, EventArgs e)
        {
            foreach (Form FormLab in Application.OpenForms)
            {
                if (FormLab.Name == "Projekt3")
                {
                    this.Hide();
                    FormLab.Show();
                    return;
                }
            }
            Projekt3 FormProjekt = new Projekt3();
            this.Hide();
            FormProjekt.Show();
        }
    }
}
