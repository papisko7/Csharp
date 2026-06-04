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
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        RecalculateSyggestion();
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        RecalculateSyggestion();
    }

    private void RecalculateSyggestion()
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
            return;
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
                typeSuggestionLbl.Text = "Suggested type: not enough data";
            }
            else
            {
                typeSuggestionLbl.Text = "Suggested type: [Gotowe na algorytm]";
            }
        }
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
}