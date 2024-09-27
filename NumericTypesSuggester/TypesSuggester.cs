using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Numerics;
using System.Windows.Forms;

namespace NumericTypesSuggester
{

    internal class TypesSuggester
    {
        private MainForm _form1;

        public TypesSuggester(MainForm form1)
        {
            _form1 = form1;
        }

        private BigInteger _minValue;
        private BigInteger _maxValue;

        private Dictionary<string, (BigInteger, BigInteger)> _integerTypes = new()
        {
            ["sbyte"] = (sbyte.MinValue, sbyte.MaxValue),
            ["byte"] = (byte.MinValue, byte.MaxValue),
            ["short"] = (short.MinValue, short.MaxValue),
            ["ushort"] = (ushort.MinValue, ushort.MaxValue),
            ["int"] = (int.MinValue, int.MaxValue),
            ["uint"] = (uint.MinValue, uint.MaxValue),
            ["long"] = (long.MinValue, long.MaxValue),
            ["ulong"] = (ulong.MinValue, ulong.MaxValue)
        };
        private Dictionary<string, (double, double)> _floatPointTypes = new()
        {
            ["float"] = (float.MinValue, float.MaxValue),
            ["double"] = (double.MinValue, double.MaxValue),
            ["decimal"] = ((double)decimal.MinValue, (double)decimal.MaxValue)
        };

        public void SuggestType()
        {
            try
            {
                if (_form1.mustBePreciseCheckBox.Checked && !_form1.IntegralOnlyCheckBox.Checked)
                {
                    decimal minDecimal = (decimal)_minValue;
                    decimal maxDecimal = (decimal)_maxValue;

                    if (minDecimal >= decimal.MinValue && maxDecimal <= decimal.MaxValue)
                    {
                        _form1.typeOfNumberLabel.Text = "decimal";
                        return;
                    }
                }

                if (!_form1.IntegralOnlyCheckBox.Checked)
                {
                    double minDouble = (double)_minValue;
                    double maxDouble = (double)_maxValue;

                    if (minDouble >= _floatPointTypes["float"].Item1 && maxDouble <= _floatPointTypes["float"].Item2)
                    {
                        _form1.typeOfNumberLabel.Text = "float";
                        return;
                    }
                    else if (minDouble >= _floatPointTypes["double"].Item1 && maxDouble <= _floatPointTypes["double"].Item2)
                    {
                        _form1.typeOfNumberLabel.Text = "double";
                        return;
                    }
                    else
                    {
                        _form1.typeOfNumberLabel.Text = "Input value is too big for floating point types";
                        return;
                    }
                }

                foreach (var type in _integerTypes.Values)
                {
                    if ((type.Item1 <= _minValue && _minValue < type.Item2)
                        && (_minValue <= _maxValue && _maxValue <= type.Item2))
                    {
                        _form1.typeOfNumberLabel.Text = _integerTypes
                            .Where(kv => kv.Value.Item2 >= type.Item2)
                            .Select(kv => kv.Key)
                            .FirstOrDefault();
                        return;
                    }
                }
            }
            catch (OverflowException)
            {
                _form1.typeOfNumberLabel.Text = "Input value is too big for such type";
                return;
            }
            _form1.typeOfNumberLabel.Text = "BigInteger";
        }

        public void ValidateInputValue(TextBox textBoxOfValue)
        {
            var inputValue = textBoxOfValue.Text;

            if ((!string.IsNullOrEmpty(_form1.MaxValueTextBox.Text)
                && !string.IsNullOrEmpty(_form1.MinValueTextBox.Text))
                && !_form1.MinValueTextBox.Text.Equals("-")
                && _maxValue >= _minValue)
            {
                _form1.MaxValueTextBox.BackColor = Color.White;
                _maxValue = BigInteger.Parse(inputValue);
                _minValue = BigInteger.Parse(inputValue);

                SuggestType();
            }
            else
            {
                _form1.MaxValueTextBox.BackColor = Color.Red;
                _form1.typeOfNumberLabel.Text = "Invalid input";
            }
        }
    }
}
