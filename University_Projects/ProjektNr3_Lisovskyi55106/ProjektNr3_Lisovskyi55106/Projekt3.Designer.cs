
namespace ProjektNr3_Lisovskyi55106
{
    partial class Projekt3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.SLrtbPrint = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SLtxtVenteces = new System.Windows.Forms.TextBox();
            this.SLtxtEdges = new System.Windows.Forms.TextBox();
            this.SLbtnAkceptacja = new System.Windows.Forms.Button();
            this.SLbtnWizualizacja = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SLtxtVertexStart = new System.Windows.Forms.TextBox();
            this.SLtxtVertexEnd = new System.Windows.Forms.TextBox();
            this.SLbtnDodaj = new System.Windows.Forms.Button();
            this.SLbtnExampleList = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SLtxtStart = new System.Windows.Forms.TextBox();
            this.SLbtnBFS = new System.Windows.Forms.Button();
            this.SLbtnClean = new System.Windows.Forms.Button();
            this.SLbtnPowrot = new System.Windows.Forms.Button();
            this.SLerrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SLerrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(716, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "                Reprezentacja grafu przy opisie przez listę sąsiedztwa \r\noraz wyz" +
    "naczenie drogi grafu za pomocą algorytmu Breadth-First Search\r\n\r\n";
            // 
            // SLrtbPrint
            // 
            this.SLrtbPrint.Enabled = false;
            this.SLrtbPrint.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLrtbPrint.Location = new System.Drawing.Point(3, 92);
            this.SLrtbPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLrtbPrint.Name = "SLrtbPrint";
            this.SLrtbPrint.Size = new System.Drawing.Size(484, 447);
            this.SLrtbPrint.TabIndex = 18;
            this.SLrtbPrint.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(512, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 40);
            this.label2.TabIndex = 19;
            this.label2.Text = "Podaj liczbę \r\nwierzchołków";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(722, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 40);
            this.label3.TabIndex = 20;
            this.label3.Text = "Podaj liczbę \r\nkrawędzi";
            // 
            // SLtxtVenteces
            // 
            this.SLtxtVenteces.Location = new System.Drawing.Point(516, 127);
            this.SLtxtVenteces.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLtxtVenteces.Name = "SLtxtVenteces";
            this.SLtxtVenteces.Size = new System.Drawing.Size(131, 20);
            this.SLtxtVenteces.TabIndex = 21;
            this.SLtxtVenteces.TextChanged += new System.EventHandler(this.SLtxtVenteces_TextChanged);
            // 
            // SLtxtEdges
            // 
            this.SLtxtEdges.Location = new System.Drawing.Point(726, 127);
            this.SLtxtEdges.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLtxtEdges.Name = "SLtxtEdges";
            this.SLtxtEdges.Size = new System.Drawing.Size(131, 20);
            this.SLtxtEdges.TabIndex = 22;
            // 
            // SLbtnAkceptacja
            // 
            this.SLbtnAkceptacja.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnAkceptacja.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnAkceptacja.Location = new System.Drawing.Point(516, 157);
            this.SLbtnAkceptacja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnAkceptacja.Name = "SLbtnAkceptacja";
            this.SLbtnAkceptacja.Size = new System.Drawing.Size(131, 50);
            this.SLbtnAkceptacja.TabIndex = 23;
            this.SLbtnAkceptacja.Text = "Akceptacja danych";
            this.SLbtnAkceptacja.UseVisualStyleBackColor = false;
            this.SLbtnAkceptacja.Click += new System.EventHandler(this.SLbtnAkceptacja_Click_1);
            // 
            // SLbtnWizualizacja
            // 
            this.SLbtnWizualizacja.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnWizualizacja.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnWizualizacja.Location = new System.Drawing.Point(726, 157);
            this.SLbtnWizualizacja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnWizualizacja.Name = "SLbtnWizualizacja";
            this.SLbtnWizualizacja.Size = new System.Drawing.Size(131, 50);
            this.SLbtnWizualizacja.TabIndex = 24;
            this.SLbtnWizualizacja.Text = "Wizualizacja grafu";
            this.SLbtnWizualizacja.UseVisualStyleBackColor = false;
            this.SLbtnWizualizacja.Click += new System.EventHandler(this.SLbtnWizualizacja_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(600, 212);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "Wprodadź listę sąsiedztwa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(523, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 40);
            this.label5.TabIndex = 26;
            this.label5.Text = "Podaj wierzchołek \r\nstartu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(746, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 40);
            this.label6.TabIndex = 27;
            this.label6.Text = "Podaj wierzchołek \r\nkońca";
            // 
            // SLtxtVertexStart
            // 
            this.SLtxtVertexStart.Location = new System.Drawing.Point(527, 286);
            this.SLtxtVertexStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLtxtVertexStart.Name = "SLtxtVertexStart";
            this.SLtxtVertexStart.Size = new System.Drawing.Size(141, 20);
            this.SLtxtVertexStart.TabIndex = 28;
            // 
            // SLtxtVertexEnd
            // 
            this.SLtxtVertexEnd.Location = new System.Drawing.Point(750, 286);
            this.SLtxtVertexEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLtxtVertexEnd.Name = "SLtxtVertexEnd";
            this.SLtxtVertexEnd.Size = new System.Drawing.Size(141, 20);
            this.SLtxtVertexEnd.TabIndex = 29;
            // 
            // SLbtnDodaj
            // 
            this.SLbtnDodaj.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnDodaj.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnDodaj.Location = new System.Drawing.Point(527, 316);
            this.SLbtnDodaj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnDodaj.Name = "SLbtnDodaj";
            this.SLbtnDodaj.Size = new System.Drawing.Size(141, 43);
            this.SLbtnDodaj.TabIndex = 30;
            this.SLbtnDodaj.Text = "Dodaj do listy sąsiedztwa";
            this.SLbtnDodaj.UseVisualStyleBackColor = false;
            this.SLbtnDodaj.Click += new System.EventHandler(this.SLbtnDodaj_Click_1);
            // 
            // SLbtnExampleList
            // 
            this.SLbtnExampleList.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnExampleList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnExampleList.Location = new System.Drawing.Point(527, 369);
            this.SLbtnExampleList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnExampleList.Name = "SLbtnExampleList";
            this.SLbtnExampleList.Size = new System.Drawing.Size(141, 55);
            this.SLbtnExampleList.TabIndex = 31;
            this.SLbtnExampleList.Text = "Przykładowa lista sąsiedztwa";
            this.SLbtnExampleList.UseVisualStyleBackColor = false;
            this.SLbtnExampleList.Click += new System.EventHandler(this.SLbtnExampleList_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(746, 319);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 40);
            this.label7.TabIndex = 32;
            this.label7.Text = "Podaj wierzchołek startu \r\ndla algorytmu BFS";
            // 
            // SLtxtStart
            // 
            this.SLtxtStart.Location = new System.Drawing.Point(750, 364);
            this.SLtxtStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLtxtStart.Name = "SLtxtStart";
            this.SLtxtStart.Size = new System.Drawing.Size(141, 20);
            this.SLtxtStart.TabIndex = 33;
            // 
            // SLbtnBFS
            // 
            this.SLbtnBFS.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnBFS.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnBFS.Location = new System.Drawing.Point(750, 394);
            this.SLbtnBFS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnBFS.Name = "SLbtnBFS";
            this.SLbtnBFS.Size = new System.Drawing.Size(141, 50);
            this.SLbtnBFS.TabIndex = 34;
            this.SLbtnBFS.Text = "Wykonaj";
            this.SLbtnBFS.UseVisualStyleBackColor = false;
            this.SLbtnBFS.Click += new System.EventHandler(this.SLbtnBFS_Click_1);
            // 
            // SLbtnClean
            // 
            this.SLbtnClean.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnClean.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnClean.Location = new System.Drawing.Point(750, 454);
            this.SLbtnClean.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnClean.Name = "SLbtnClean";
            this.SLbtnClean.Size = new System.Drawing.Size(141, 50);
            this.SLbtnClean.TabIndex = 35;
            this.SLbtnClean.Text = "Resetuj";
            this.SLbtnClean.UseVisualStyleBackColor = false;
            this.SLbtnClean.Click += new System.EventHandler(this.SLbtnClean_Click_1);
            // 
            // SLbtnPowrot
            // 
            this.SLbtnPowrot.BackColor = System.Drawing.Color.Transparent;
            this.SLbtnPowrot.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnPowrot.Location = new System.Drawing.Point(879, 9);
            this.SLbtnPowrot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SLbtnPowrot.Name = "SLbtnPowrot";
            this.SLbtnPowrot.Size = new System.Drawing.Size(98, 56);
            this.SLbtnPowrot.TabIndex = 36;
            this.SLbtnPowrot.Text = "Powrót do ekranu głównego";
            this.SLbtnPowrot.UseVisualStyleBackColor = false;
            this.SLbtnPowrot.Click += new System.EventHandler(this.SLbtnPowrot_Click_1);
            // 
            // SLerrorProvider1
            // 
            this.SLerrorProvider1.ContainerControl = this;
            // 
            // Projekt3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 543);
            this.Controls.Add(this.SLbtnPowrot);
            this.Controls.Add(this.SLbtnClean);
            this.Controls.Add(this.SLbtnBFS);
            this.Controls.Add(this.SLtxtStart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SLbtnExampleList);
            this.Controls.Add(this.SLbtnDodaj);
            this.Controls.Add(this.SLtxtVertexEnd);
            this.Controls.Add(this.SLtxtVertexStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SLbtnWizualizacja);
            this.Controls.Add(this.SLbtnAkceptacja);
            this.Controls.Add(this.SLtxtEdges);
            this.Controls.Add(this.SLtxtVenteces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SLrtbPrint);
            this.Controls.Add(this.label1);
            this.Name = "Projekt3";
            this.Text = "Projekt3";
            ((System.ComponentModel.ISupportInitialize)(this.SLerrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox SLrtbPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SLtxtVenteces;
        private System.Windows.Forms.TextBox SLtxtEdges;
        private System.Windows.Forms.Button SLbtnAkceptacja;
        private System.Windows.Forms.Button SLbtnWizualizacja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SLtxtVertexStart;
        private System.Windows.Forms.TextBox SLtxtVertexEnd;
        private System.Windows.Forms.Button SLbtnDodaj;
        private System.Windows.Forms.Button SLbtnExampleList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SLtxtStart;
        private System.Windows.Forms.Button SLbtnBFS;
        private System.Windows.Forms.Button SLbtnClean;
        private System.Windows.Forms.Button SLbtnPowrot;
        private System.Windows.Forms.ErrorProvider SLerrorProvider1;
    }
}