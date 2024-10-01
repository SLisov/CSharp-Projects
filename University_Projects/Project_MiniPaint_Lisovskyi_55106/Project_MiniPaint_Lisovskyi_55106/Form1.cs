using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_MiniPaint_Lisovskyi_55106
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }

        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;
        Point px, py;
        Pen pen1 = new Pen(Color.Black, 2f);
        int x, y, sX, sY, cX, cY;

        private bool Painting = false;
        int index;
       
        
        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);
            pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            graphics.Clear(Color.White);
            pictureBox1.Image = map;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(.*JPG)|*.jpg";
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Nothing To Save");
            }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Painting = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Painting)
            {
                if (index == 4)
                {
                    px = e.Location;
                    graphics.DrawLine(pen1, px, py);
                    py = px;
                }
            }
            pictureBox1.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Painting = false;
           

            sX = x - cX;
            sY = y - cY;

            if (index == 1)
            {
                graphics.DrawEllipse(pen1, cX, cY, sX, sY);
            }

            if (index == 2)
            {
                graphics.DrawRectangle(pen1, cX, cY, sX, sY);
            }

            if (index == 3)
            {
                graphics.DrawLine(pen1, cX, cY, x, y);
            }
        }

       

        private void button11_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (Painting)
            {
                if (index == 1)
                {
                    graphics.DrawEllipse(pen1, cX, cY, sX, sY);
                }

                if (index == 2)
                {
                    graphics.DrawRectangle(pen1, cX, cY, sX, sY);
                }

                if (index == 3)
                {
                    graphics.DrawLine(pen1, cX, cY, x, y);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            index = 3;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            index = 4;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pen1.Color = ((Button)sender).BackColor;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen1.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen1.Width = trackBar1.Value;
        }

        
    }
}
