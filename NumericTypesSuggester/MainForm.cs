using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Numerics;
using System.Windows.Forms;

namespace NumericTypesSuggester
{
    public partial class MainForm : Form
    {
        private TypesSuggester _typesSuggester;

        public MainForm()
        {
            InitializeComponent();

            _typesSuggester = new TypesSuggester(this);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _typesSuggester.ValidateInputValue((TextBox)sender);
            }
            catch (Exception)
            {
                typeOfNumberLabel.Text = "Input value is Invalid or too big for such type";
                return;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs inputMax)
        {
            if (!IsValid(inputMax.KeyChar, (TextBox)sender))
            {
                inputMax.Handled = true;
            }
        }

        private void IntegralOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mustBePreciseCheckBox.Visible = !mustBePreciseCheckBox.Visible;
            _typesSuggester.SuggestType();
        }

        private void mustBePreciseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _typesSuggester.SuggestType();
        }

        private bool IsValid(char keyChar, TextBox textBox)
        {
            return char.IsControl(keyChar) || char.IsDigit(keyChar)
                || (keyChar.Equals('-')
                && !MinValueTextBox.Text.Contains("-")
                && MinValueTextBox.SelectionStart == 0
                && textBox != MaxValueTextBox);
        }
    }
}
