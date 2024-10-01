
namespace ProjektNr3_Lisovskyi55106
{
    partial class Laboratorium
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SLtxtLiczbaWierzchołkówGrafu = new System.Windows.Forms.TextBox();
            this.SLbtnMacierzWag = new System.Windows.Forms.Button();
            this.SLbtnPrzykładowaMacierzWag = new System.Windows.Forms.Button();
            this.SLbtnAkceptacjaMacierzyWag = new System.Windows.Forms.Button();
            this.SLbtnWyznaczŚcieżkiWgrafie = new System.Windows.Forms.Button();
            this.SLlblMacierzWag = new System.Windows.Forms.Label();
            this.SLdgvMacierzWag = new System.Windows.Forms.DataGridView();
            this.SLlblMacierzOdległości = new System.Windows.Forms.Label();
            this.SLlblMacierzWęzłów = new System.Windows.Forms.Label();
            this.SLdgvMacierzOdległości = new System.Windows.Forms.DataGridView();
            this.SLdgvMacierzWęzłówPośrednich = new System.Windows.Forms.DataGridView();
            this.SLerrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SLdgvMacierzWag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLdgvMacierzOdległości)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLdgvMacierzWęzłówPośrednich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLerrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(123, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "    Algorytm Floyda_Warshalla umożliwia wyznaczenie najkrótszych\r\n śzieżek (tras)" +
    " pomiędzy wszystkimi wierzchołkami grafu skierowanego";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opis grafu: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Liczba wierzchołków grafu: ";
            // 
            // SLtxtLiczbaWierzchołkówGrafu
            // 
            this.SLtxtLiczbaWierzchołkówGrafu.Location = new System.Drawing.Point(16, 150);
            this.SLtxtLiczbaWierzchołkówGrafu.Name = "SLtxtLiczbaWierzchołkówGrafu";
            this.SLtxtLiczbaWierzchołkówGrafu.Size = new System.Drawing.Size(155, 20);
            this.SLtxtLiczbaWierzchołkówGrafu.TabIndex = 3;
            // 
            // SLbtnMacierzWag
            // 
            this.SLbtnMacierzWag.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnMacierzWag.Location = new System.Drawing.Point(16, 176);
            this.SLbtnMacierzWag.Name = "SLbtnMacierzWag";
            this.SLbtnMacierzWag.Size = new System.Drawing.Size(155, 72);
            this.SLbtnMacierzWag.TabIndex = 4;
            this.SLbtnMacierzWag.Text = "Utwórz i pokaż macierz wag(sąsiedztwa)";
            this.SLbtnMacierzWag.UseVisualStyleBackColor = true;
            this.SLbtnMacierzWag.Click += new System.EventHandler(this.SLbtnMacierzWag_Click);
            // 
            // SLbtnPrzykładowaMacierzWag
            // 
            this.SLbtnPrzykładowaMacierzWag.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnPrzykładowaMacierzWag.Location = new System.Drawing.Point(16, 254);
            this.SLbtnPrzykładowaMacierzWag.Name = "SLbtnPrzykładowaMacierzWag";
            this.SLbtnPrzykładowaMacierzWag.Size = new System.Drawing.Size(155, 72);
            this.SLbtnPrzykładowaMacierzWag.TabIndex = 5;
            this.SLbtnPrzykładowaMacierzWag.Text = "Przykładowa macierz wag";
            this.SLbtnPrzykładowaMacierzWag.UseVisualStyleBackColor = true;
            this.SLbtnPrzykładowaMacierzWag.Click += new System.EventHandler(this.SLbtnPrzykładowaMacierzWag_Click);
            // 
            // SLbtnAkceptacjaMacierzyWag
            // 
            this.SLbtnAkceptacjaMacierzyWag.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnAkceptacjaMacierzyWag.Location = new System.Drawing.Point(16, 332);
            this.SLbtnAkceptacjaMacierzyWag.Name = "SLbtnAkceptacjaMacierzyWag";
            this.SLbtnAkceptacjaMacierzyWag.Size = new System.Drawing.Size(155, 72);
            this.SLbtnAkceptacjaMacierzyWag.TabIndex = 6;
            this.SLbtnAkceptacjaMacierzyWag.Text = "Zaakceptuj wprowadzone dane w macierzy wag";
            this.SLbtnAkceptacjaMacierzyWag.UseVisualStyleBackColor = true;
            this.SLbtnAkceptacjaMacierzyWag.Click += new System.EventHandler(this.SLbtnAkceptacjaMacierzyWag_Click);
            // 
            // SLbtnWyznaczŚcieżkiWgrafie
            // 
            this.SLbtnWyznaczŚcieżkiWgrafie.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnWyznaczŚcieżkiWgrafie.Location = new System.Drawing.Point(16, 410);
            this.SLbtnWyznaczŚcieżkiWgrafie.Name = "SLbtnWyznaczŚcieżkiWgrafie";
            this.SLbtnWyznaczŚcieżkiWgrafie.Size = new System.Drawing.Size(155, 117);
            this.SLbtnWyznaczŚcieżkiWgrafie.TabIndex = 7;
            this.SLbtnWyznaczŚcieżkiWgrafie.Text = "Wyznacz najkrótsze śzieżki w grafie według algorytmu Floyda_Warshalla";
            this.SLbtnWyznaczŚcieżkiWgrafie.UseVisualStyleBackColor = true;
            this.SLbtnWyznaczŚcieżkiWgrafie.Click += new System.EventHandler(this.SLbtnWyznaczŚcieżkiWgrafie_Click);
            // 
            // SLlblMacierzWag
            // 
            this.SLlblMacierzWag.AutoSize = true;
            this.SLlblMacierzWag.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLlblMacierzWag.Location = new System.Drawing.Point(290, 87);
            this.SLlblMacierzWag.Name = "SLlblMacierzWag";
            this.SLlblMacierzWag.Size = new System.Drawing.Size(209, 20);
            this.SLlblMacierzWag.TabIndex = 8;
            this.SLlblMacierzWag.Text = "Macierz wag ( sąsiedztwa) : ";
            // 
            // SLdgvMacierzWag
            // 
            this.SLdgvMacierzWag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SLdgvMacierzWag.Location = new System.Drawing.Point(294, 110);
            this.SLdgvMacierzWag.Name = "SLdgvMacierzWag";
            this.SLdgvMacierzWag.Size = new System.Drawing.Size(321, 130);
            this.SLdgvMacierzWag.TabIndex = 9;
            // 
            // SLlblMacierzOdległości
            // 
            this.SLlblMacierzOdległości.AutoSize = true;
            this.SLlblMacierzOdległości.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLlblMacierzOdległości.Location = new System.Drawing.Point(290, 243);
            this.SLlblMacierzOdległości.Name = "SLlblMacierzOdległości";
            this.SLlblMacierzOdległości.Size = new System.Drawing.Size(317, 20);
            this.SLlblMacierzOdległości.TabIndex = 10;
            this.SLlblMacierzOdległości.Text = "Macierz odległości między węzłami grafu: ";
            // 
            // SLlblMacierzWęzłów
            // 
            this.SLlblMacierzWęzłów.AutoSize = true;
            this.SLlblMacierzWęzłów.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLlblMacierzWęzłów.Location = new System.Drawing.Point(290, 399);
            this.SLlblMacierzWęzłów.Name = "SLlblMacierzWęzłów";
            this.SLlblMacierzWęzłów.Size = new System.Drawing.Size(214, 20);
            this.SLlblMacierzWęzłów.TabIndex = 11;
            this.SLlblMacierzWęzłów.Text = "Macierz węzłów pośrednich:";
            // 
            // SLdgvMacierzOdległości
            // 
            this.SLdgvMacierzOdległości.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SLdgvMacierzOdległości.Location = new System.Drawing.Point(294, 266);
            this.SLdgvMacierzOdległości.Name = "SLdgvMacierzOdległości";
            this.SLdgvMacierzOdległości.Size = new System.Drawing.Size(322, 130);
            this.SLdgvMacierzOdległości.TabIndex = 13;
            this.SLdgvMacierzOdległości.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SLdgvMacierzOdległości_CellContentClick);
            // 
            // SLdgvMacierzWęzłówPośrednich
            // 
            this.SLdgvMacierzWęzłówPośrednich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SLdgvMacierzWęzłówPośrednich.Location = new System.Drawing.Point(294, 422);
            this.SLdgvMacierzWęzłówPośrednich.Name = "SLdgvMacierzWęzłówPośrednich";
            this.SLdgvMacierzWęzłówPośrednich.Size = new System.Drawing.Size(322, 130);
            this.SLdgvMacierzWęzłówPośrednich.TabIndex = 16;
            // 
            // SLerrorProvider1
            // 
            this.SLerrorProvider1.ContainerControl = this;
            // 
            // Laboratorium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 603);
            this.Controls.Add(this.SLdgvMacierzWęzłówPośrednich);
            this.Controls.Add(this.SLdgvMacierzOdległości);
            this.Controls.Add(this.SLlblMacierzWęzłów);
            this.Controls.Add(this.SLlblMacierzOdległości);
            this.Controls.Add(this.SLdgvMacierzWag);
            this.Controls.Add(this.SLlblMacierzWag);
            this.Controls.Add(this.SLbtnWyznaczŚcieżkiWgrafie);
            this.Controls.Add(this.SLbtnAkceptacjaMacierzyWag);
            this.Controls.Add(this.SLbtnPrzykładowaMacierzWag);
            this.Controls.Add(this.SLbtnMacierzWag);
            this.Controls.Add(this.SLtxtLiczbaWierzchołkówGrafu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Laboratorium";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.SLdgvMacierzWag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLdgvMacierzOdległości)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLdgvMacierzWęzłówPośrednich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SLerrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SLtxtLiczbaWierzchołkówGrafu;
        private System.Windows.Forms.Button SLbtnMacierzWag;
        private System.Windows.Forms.Button SLbtnPrzykładowaMacierzWag;
        private System.Windows.Forms.Button SLbtnAkceptacjaMacierzyWag;
        private System.Windows.Forms.Button SLbtnWyznaczŚcieżkiWgrafie;
        private System.Windows.Forms.Label SLlblMacierzWag;
        private System.Windows.Forms.DataGridView SLdgvMacierzWag;
        private System.Windows.Forms.Label SLlblMacierzOdległości;
        private System.Windows.Forms.Label SLlblMacierzWęzłów;
        private System.Windows.Forms.DataGridView SLdgvMacierzOdległości;
        private System.Windows.Forms.DataGridView SLdgvMacierzWęzłówPośrednich;
        private System.Windows.Forms.ErrorProvider SLerrorProvider1;
    }
}