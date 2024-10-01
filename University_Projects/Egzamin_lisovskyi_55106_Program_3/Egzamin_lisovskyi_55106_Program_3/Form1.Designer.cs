
namespace Egzamin_lisovskyi_55106_Program_3
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.object1 = new System.Windows.Forms.PictureBox();
            this.object2 = new System.Windows.Forms.PictureBox();
            this.object3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.object1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.object2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.object3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // object1
            // 
            this.object1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.object1.Location = new System.Drawing.Point(368, 242);
            this.object1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.object1.Name = "object1";
            this.object1.Size = new System.Drawing.Size(57, 45);
            this.object1.TabIndex = 0;
            this.object1.TabStop = false;
            this.object1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // object2
            // 
            this.object2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.object2.Location = new System.Drawing.Point(606, 98);
            this.object2.Name = "object2";
            this.object2.Size = new System.Drawing.Size(62, 54);
            this.object2.TabIndex = 1;
            this.object2.TabStop = false;
            // 
            // object3
            // 
            this.object3.BackColor = System.Drawing.SystemColors.Info;
            this.object3.Location = new System.Drawing.Point(132, 442);
            this.object3.Name = "object3";
            this.object3.Size = new System.Drawing.Size(61, 55);
            this.object3.TabIndex = 2;
            this.object3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 615);
            this.Controls.Add(this.object3);
            this.Controls.Add(this.object2);
            this.Controls.Add(this.object1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.object1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.object2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.object3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox object1;
        private System.Windows.Forms.PictureBox object2;
        private System.Windows.Forms.PictureBox object3;
    }
}

