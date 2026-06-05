using System.Numerics;

namespace NumericTypesSuggester
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			RegisterEvents();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RecalculateSuggestion();
		}

		private void RegisterEvents()
		{
			minValueTxtBx.KeyPress += TextBox_KeyPress;
			maxValueTxtBx.KeyPress += TextBox_KeyPress;

			minValueTxtBx.TextChanged += TextBox_TextChanged;
			maxValueTxtBx.TextChanged += TextBox_TextChanged;

			integralChckBx.CheckedChanged += IntegralChckBx_CheckedChanged;
			preciseChBx.CheckedChanged += PreciseChBx_CheckedChanged;
		}

		private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
		{
			if (sender is not TextBox textBox)
			{
				return;
			}

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

		private void TextBox_TextChanged(object? sender, EventArgs e)
		{
			RecalculateSuggestion();
		}

		private void IntegralChckBx_CheckedChanged(object? sender, EventArgs e)
		{
			preciseChBx.Visible = !integralChckBx.Checked;
			RecalculateSuggestion();
		}

		private void PreciseChBx_CheckedChanged(object? sender, EventArgs e)
		{
			RecalculateSuggestion();
		}

		private void RecalculateSuggestion()
		{
			string minText = minValueTxtBx.Text;
			string maxText = maxValueTxtBx.Text;

			maxValueTxtBx.BackColor = Color.White;
			if (IsInputInvalid(minText) || IsInputInvalid(maxText))
			{
				typeSuggestionLbl.Text = AppStrings.NotEnoughData;
				return;
			}

			if (BigInteger.TryParse(minText, out BigInteger minValue) &&
				BigInteger.TryParse(maxText, out BigInteger maxValue))
			{
				if (maxValue < minValue)
				{
					maxValueTxtBx.BackColor = Color.Red;
					typeSuggestionLbl.Text = AppStrings.NotEnoughData;

					return;
				}

				string resultType = TypeSuggester.Suggest(
					minValue,
					maxValue,
					integralChckBx.Checked,
					preciseChBx.Checked
				);

				typeSuggestionLbl.Text = string.Format(AppStrings.SuggestedTypeFormat, resultType);
			}
		}

		private bool IsInputInvalid(string text)
		{
			return string.IsNullOrWhiteSpace(text)
				|| text == "-";
		}
	}
}