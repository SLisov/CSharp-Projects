
namespace ProjektNr3_Lisovskyi55106
{
    partial class Pulpit
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
            this.SLbtnLaboratorium = new System.Windows.Forms.Button();
            this.SLbtnProjekt3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SLbtnLaboratorium
            // 
            this.SLbtnLaboratorium.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnLaboratorium.Location = new System.Drawing.Point(108, 142);
            this.SLbtnLaboratorium.Name = "SLbtnLaboratorium";
            this.SLbtnLaboratorium.Size = new System.Drawing.Size(240, 70);
            this.SLbtnLaboratorium.TabIndex = 0;
            this.SLbtnLaboratorium.Text = "Laboratorium: wznacznie ścieżek w grafie";
            this.SLbtnLaboratorium.UseVisualStyleBackColor = true;
            this.SLbtnLaboratorium.Click += new System.EventHandler(this.SLbtnLaboratorium_Click);
            // 
            // SLbtnProjekt3
            // 
            this.SLbtnProjekt3.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnProjekt3.Location = new System.Drawing.Point(431, 142);
            this.SLbtnProjekt3.Name = "SLbtnProjekt3";
            this.SLbtnProjekt3.Size = new System.Drawing.Size(240, 70);
            this.SLbtnProjekt3.TabIndex = 1;
            this.SLbtnProjekt3.Text = "Projekt Nr 3 Lisovskyi55106: zastosowania grafów";
            this.SLbtnProjekt3.UseVisualStyleBackColor = true;
            this.SLbtnProjekt3.Click += new System.EventHandler(this.SLbtnProjekt3_Click);
            // 
            // Pulpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SLbtnProjekt3);
            this.Controls.Add(this.SLbtnLaboratorium);
            this.Name = "Pulpit";
            this.Text = "PULPIT";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SLbtnLaboratorium;
        private System.Windows.Forms.Button SLbtnProjekt3;
    }
}

