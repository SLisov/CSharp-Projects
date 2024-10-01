
namespace ProjektNr2_Lisovskyi55106
{
    partial class FormularzGlowny
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SLbtnLaboratorium = new System.Windows.Forms.Button();
            this.SLbtnProjekt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(121, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(602, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analizator złożoności obliczeniowej algorytmów sortowania";
            // 
            // SLbtnLaboratorium
            // 
            this.SLbtnLaboratorium.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnLaboratorium.Location = new System.Drawing.Point(126, 181);
            this.SLbtnLaboratorium.Name = "SLbtnLaboratorium";
            this.SLbtnLaboratorium.Size = new System.Drawing.Size(257, 65);
            this.SLbtnLaboratorium.TabIndex = 1;
            this.SLbtnLaboratorium.Text = "Analiza złożoności algorytmów z zajęć laboratoryjnych";
            this.SLbtnLaboratorium.UseVisualStyleBackColor = true;
            this.SLbtnLaboratorium.Click += new System.EventHandler(this.SLbtnLaboratorium_Click);
            // 
            // SLbtnProjekt
            // 
            this.SLbtnProjekt.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SLbtnProjekt.Location = new System.Drawing.Point(466, 181);
            this.SLbtnProjekt.Name = "SLbtnProjekt";
            this.SLbtnProjekt.Size = new System.Drawing.Size(257, 65);
            this.SLbtnProjekt.TabIndex = 2;
            this.SLbtnProjekt.Text = "Analiza złożoności algorytmów PrjektuNr2_Lisovskyi";
            this.SLbtnProjekt.UseVisualStyleBackColor = true;
            this.SLbtnProjekt.Click += new System.EventHandler(this.SLbtnProjekt_Click);
            // 
            // FormularzGlowny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 504);
            this.Controls.Add(this.SLbtnProjekt);
            this.Controls.Add(this.SLbtnLaboratorium);
            this.Controls.Add(this.label1);
            this.Name = "FormularzGlowny";
            this.Text = "Strona Golowna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SLbtnLaboratorium;
        private System.Windows.Forms.Button SLbtnProjekt;
    }
}

