namespace NumericTypesSuggester
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            IntegralOnlyCheckBox = new CheckBox();
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            mustBePreciseCheckBox = new CheckBox();
            label3 = new Label();
            typeOfNumberLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(32, 35);
            label1.Name = "label1";
            label1.Size = new Size(175, 46);
            label1.TabIndex = 0;
            label1.Text = "Min Value:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(32, 99);
            label2.Name = "label2";
            label2.Size = new Size(181, 46);
            label2.TabIndex = 1;
            label2.Text = "Max Value:";
            // 
            // IntegralOnlyCheckBox
            // 
            IntegralOnlyCheckBox.AutoSize = true;
            IntegralOnlyCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            IntegralOnlyCheckBox.Checked = true;
            IntegralOnlyCheckBox.CheckState = CheckState.Checked;
            IntegralOnlyCheckBox.Font = new Font("Segoe UI", 15F);
            IntegralOnlyCheckBox.Location = new Point(49, 193);
            IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
            IntegralOnlyCheckBox.RightToLeft = RightToLeft.No;
            IntegralOnlyCheckBox.Size = new Size(187, 39);
            IntegralOnlyCheckBox.TabIndex = 2;
            IntegralOnlyCheckBox.Text = "Integral only?";
            IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
            IntegralOnlyCheckBox.CheckedChanged += IntegralOnlyCheckBox_CheckedChanged;
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinValueTextBox.Location = new Point(213, 38);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(559, 43);
            MinValueTextBox.TabIndex = 3;
            MinValueTextBox.TextChanged += TextBox_TextChanged;
            MinValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaxValueTextBox.Location = new Point(213, 102);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(559, 43);
            MaxValueTextBox.TabIndex = 4;
            MaxValueTextBox.TextChanged += TextBox_TextChanged;
            MaxValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // mustBePreciseCheckBox
            // 
            mustBePreciseCheckBox.AutoSize = true;
            mustBePreciseCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            mustBePreciseCheckBox.Font = new Font("Segoe UI", 15F);
            mustBePreciseCheckBox.Location = new Point(12, 252);
            mustBePreciseCheckBox.Name = "mustBePreciseCheckBox";
            mustBePreciseCheckBox.Size = new Size(224, 39);
            mustBePreciseCheckBox.TabIndex = 5;
            mustBePreciseCheckBox.Text = "Must be precise?";
            mustBePreciseCheckBox.UseVisualStyleBackColor = true;
            mustBePreciseCheckBox.Visible = false;
            mustBePreciseCheckBox.CheckedChanged += mustBePreciseCheckBox_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label3.Location = new Point(32, 346);
            label3.Name = "label3";
            label3.Size = new Size(238, 40);
            label3.TabIndex = 6;
            label3.Text = "Suggested type:";
            // 
            // typeOfNumberLabel
            // 
            typeOfNumberLabel.AutoSize = true;
            typeOfNumberLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            typeOfNumberLabel.Location = new Point(285, 346);
            typeOfNumberLabel.Name = "typeOfNumberLabel";
            typeOfNumberLabel.Size = new Size(246, 40);
            typeOfNumberLabel.TabIndex = 7;
            typeOfNumberLabel.Text = "not enough data";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(957, 464);
            Controls.Add(typeOfNumberLabel);
            Controls.Add(label3);
            Controls.Add(mustBePreciseCheckBox);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MinValueTextBox);
            Controls.Add(IntegralOnlyCheckBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "C# Numeric Types";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox MinValueTextBox;
        public TextBox MaxValueTextBox;
        public CheckBox IntegralOnlyCheckBox;
        public CheckBox mustBePreciseCheckBox;
        public Label typeOfNumberLabel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
