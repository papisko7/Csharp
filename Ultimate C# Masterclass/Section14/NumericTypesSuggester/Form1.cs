using System.Numerics;

namespace NumericTypesSuggester;

public partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();

		minValueTxtBx.KeyPress += TextBox_KeyPress;
		maxValueTxtBx.KeyPress += TextBox_KeyPress;

		minValueTxtBx.TextChanged += TextBox_TextChanged;
		maxValueTxtBx.TextChanged += TextBox_TextChanged;

		integralChckBx.CheckedChanged += IntegralChckBx_CheckedChanged;
		preciseChBx.CheckedChanged += PreciseChBx_CheckedChanged;
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		RecalculateSuggestion();
	}

	private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
		{
			return;
		}

		if (e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains("-"))
		{
			return;
		}

		e.Handled = true;
	}

	private void TextBox_TextChanged(object sender, EventArgs e)
	{
		RecalculateSuggestion();
	}

	private void IntegralChckBx_CheckedChanged(object sender, EventArgs e)
	{
		preciseChBx.Visible = !integralChckBx.Checked;

		RecalculateSuggestion();
	}

	private void PreciseChBx_CheckedChanged(object sender, EventArgs e)
	{
		RecalculateSuggestion();
	}

	private void RecalculateSuggestion()
	{
		var minText = minValueTxtBx.Text;
		var maxText = maxValueTxtBx.Text;

		maxValueTxtBx.BackColor = Color.White;

		ValidateMinMaxText(minText, maxText);
		ParseMinMaxTextToBigInt(minText, maxText);
	}

	private void ValidateMinMaxText(string minText, string maxText)
	{
		if (string.IsNullOrWhiteSpace(minText) || minText.Equals("-")
			|| string.IsNullOrWhiteSpace(maxText) || maxText.Equals("-"))
		{
			typeSuggestionLbl.Text = @"Suggested type: not enough data";
		}

		return;
	}

	private void ParseMinMaxTextToBigInt(string minText, string maxText)
	{
		if (BigInteger.TryParse(minText, out BigInteger minValue) &&
			BigInteger.TryParse(maxText, out BigInteger maxValue))
		{
			if (maxValue < minValue)
			{
				maxValueTxtBx.BackColor = Color.Red;
				typeSuggestionLbl.Text = "Wrong input! Max value has to be greater than min value";
			}
			else
			{
				string suggestedType;
				if (integralChckBx.Checked)
				{
					suggestedType = GetSuggestedIntegralType(minValue, maxValue);
				}
				else
				{
					suggestedType = GetSuggestedFloatingPointType(minValue, maxValue, preciseChBx.Checked);
				}

				typeSuggestionLbl.Text = $"Suggested type: {suggestedType}";
			}
		}
	}

	private string GetSuggestedIntegralType(BigInteger minValue, BigInteger maxValue)
	{
		if (minValue >= 0)
		{
			if (maxValue <= byte.MaxValue)
			{
				return "byte";
			}

			if (maxValue <= ushort.MaxValue)
			{
				return "ushort";
			}

			if (maxValue <= uint.MaxValue)
			{
				return "uint";
			}

			if (maxValue <= ulong.MaxValue)
			{
				return "ulong";
			}

			return "BigInteger";
		}
		else
		{
			if (minValue >= sbyte.MinValue && maxValue <= sbyte.MaxValue)
			{
				return "sbyte";
			}

			if (minValue >= short.MinValue && maxValue <= short.MaxValue)
			{
				return "short";
			}

			if (minValue >= int.MinValue && maxValue <= int.MaxValue)
			{
				return "int";
			}

			if (minValue >= long.MinValue && maxValue <= long.MaxValue)
			{
				return "long";
			}

			return "BigInteger";
		}
	}

	private string GetSuggestedFloatingPointType(BigInteger minValue, BigInteger maxValue, bool mustBePercise)
	{
		if (mustBePercise)
		{
			if (minValue >= (BigInteger)decimal.MinValue && maxValue <= (BigInteger)decimal.MaxValue)
			{
				return "decimal";
			}

			return "Impossible representation";
		}
		else
		{
			if (minValue >= (BigInteger)float.MinValue && maxValue <= (BigInteger)float.MaxValue)
			{
				return "float";
			}
			if (minValue >= (BigInteger)double.MinValue && maxValue <= (BigInteger)double.MaxValue)
			{
				return "double";
			}

			return "Impossible representation";
		}
	}
}