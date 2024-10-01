using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Egzamin_lisovskyi_55106_Program_3
{
    public partial class Form1 : Form
    {

        bool LeftMove;
        bool UpMove;
        public Form1()
        {
            InitializeComponent();
        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LeftMove == true)
            {
                object1.Left += 10;
                object2.Left += 10;
                object3.Left += 10;

            }
            if (LeftMove == false) {
                object1.Left -= 10;
                object2.Left -= 10;
                object3.Left -= 10;
            }
            if (UpMove == true)
            {
                object1.Top += 10;
                object2.Top += 10;
                object3.Top += 10;
            }
            if (UpMove == false)
            {
                object1.Top -= 10;
                object2.Top -= 10;
                object3.Top -= 10;
            }
            if (object1.Left <= ClientRectangle.Left || object2.Left <= ClientRectangle.Left || object3.Left <= ClientRectangle.Left)
            {
                LeftMove = true;
            }
            if (object1.Right >= ClientRectangle.Right || object2.Right >= ClientRectangle.Right || object3.Right >= ClientRectangle.Right)
            {
                LeftMove = false;
            }
            if (object1.Top <= ClientRectangle.Top || object2.Top <= ClientRectangle.Top || object3.Top <= ClientRectangle.Top)
            {
                UpMove = true;
            }
            if (object1.Bottom >= ClientRectangle.Bottom || object2.Bottom >= ClientRectangle.Bottom || object3.Bottom >= ClientRectangle.Bottom)
            {
                UpMove = false;
            }
        }
    }
}
