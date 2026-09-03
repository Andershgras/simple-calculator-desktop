using System.Globalization;

namespace SimpleCalculator
{
    public partial class CalculatorForm : Form
    {
        private double firstNumber = 0;
        private string currentOperator = "";
        private string pendingCalculation = "";
        private bool isNewNumber = true;
        private bool hasError = false;

        public CalculatorForm()
        {
            InitializeComponent();
            btnDecimal.Text = ".";
            KeyPreview = true;
            KeyDown += CalculatorForm_KeyDown;
            KeyPress += CalculatorForm_KeyPress;
        }

        private void CalculatorForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyDisplayValueToClipboard();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnEquals.PerformClick();
                    break;
                case Keys.Escape:
                    btnClear.PerformClick();
                    break;
                case Keys.Back:
                    btnBackspace.PerformClick();
                    break;
                default:
                    return;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void CalculatorForm_KeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    btn0.PerformClick();
                    break;
                case '1':
                    btn1.PerformClick();
                    break;
                case '2':
                    btn2.PerformClick();
                    break;
                case '3':
                    btn3.PerformClick();
                    break;
                case '4':
                    btn4.PerformClick();
                    break;
                case '5':
                    btn5.PerformClick();
                    break;
                case '6':
                    btn6.PerformClick();
                    break;
                case '7':
                    btn7.PerformClick();
                    break;
                case '8':
                    btn8.PerformClick();
                    break;
                case '9':
                    btn9.PerformClick();
                    break;
                case '+':
                    btnAdd.PerformClick();
                    break;
                case '-':
                    btnSubstract.PerformClick();
                    break;
                case '*':
                    btnMultiply.PerformClick();
                    break;
                case '/':
                    btnDivide.PerformClick();
                    break;
                case '.':
                case ',':
                    btnDecimal.PerformClick();
                    break;
                default:
                    return;
            }

            e.Handled = true;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (hasError)
            {
                ResetCalculator();
            }

            Button button = (Button)sender;

            if (txtDisplay.Text == "0" || isNewNumber)
            {
                txtDisplay.Text = button.Text;
                isNewNumber = false;
            }
            else if (txtDisplay.Text == "-0")
            {
                txtDisplay.Text = "-" + button.Text;
            }
            else
            {
                txtDisplay.Text += button.Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOperator("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            SetOperator("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            SetOperator("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            SetOperator("/");
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (hasError)
            {
                return;
            }

            if (string.IsNullOrEmpty(currentOperator))
            {
                return;
            }

            if (!TryGetDisplayNumber(out double secondNumber))
            {
                ShowError("Error: Invalid input");
                return;
            }

            string historyCalculation = string.IsNullOrEmpty(pendingCalculation)
                ? string.Format(CultureInfo.InvariantCulture, "{0} {1} {2}", firstNumber, currentOperator, secondNumber)
                : string.Format(CultureInfo.InvariantCulture, "{0} {1}", pendingCalculation, secondNumber);

            if (!TryCalculate(firstNumber, currentOperator, secondNumber, out double result))
            {
                ShowError("Error: Cannot divide by zero");
                return;
            }

            txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
            lblPendingCalculation.Text = string.Format(
                CultureInfo.InvariantCulture,
                "{0} =",
                historyCalculation);
            AddHistory(historyCalculation, result);
            firstNumber = result;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            isNewNumber = true;
            hasError = false;
        }

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
            hasError = false;
            lblPendingCalculation.Text = "";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (hasError)
            {
                ResetCalculator();
            }

            if (isNewNumber)
            {
                txtDisplay.Text = "0.";
                isNewNumber = false;
                return;
            }

            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {
            if (hasError)
            {
                return;
            }

            if (txtDisplay.Text.StartsWith("-", StringComparison.Ordinal))
            {
                txtDisplay.Text = txtDisplay.Text[1..];
            }
            else
            {
                txtDisplay.Text = "-" + txtDisplay.Text;
            }

            isNewNumber = false;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (hasError || isNewNumber)
            {
                return;
            }

            txtDisplay.Text = txtDisplay.Text.Length > 1 && txtDisplay.Text != "-0"
                ? txtDisplay.Text[..^1]
                : "0";

            if (txtDisplay.Text == "-" || txtDisplay.Text == "0")
            {
                txtDisplay.Text = "0";
                isNewNumber = true;
            }
        }

        private void CopyDisplayValueToClipboard()
        {
            if (hasError || !TryGetDisplayNumber(out _))
            {
                return;
            }

            try
            {
                Clipboard.SetText(txtDisplay.Text);
            }
            catch
            {
            }
        }

        private void SetOperator(string operatorValue)
        {
            if (hasError)
            {
                return;
            }

            if (!TryGetDisplayNumber(out double currentNumber))
            {
                ShowError("Error: Invalid input");
                return;
            }

            if (!string.IsNullOrEmpty(currentOperator) && !isNewNumber)
            {
                if (!TryCalculate(firstNumber, currentOperator, currentNumber, out double intermediateResult))
                {
                    ShowError("Error: Cannot divide by zero");
                    return;
                }

                pendingCalculation = string.IsNullOrEmpty(pendingCalculation)
                    ? string.Format(CultureInfo.InvariantCulture, "{0} {1} {2}", firstNumber, currentOperator, currentNumber)
                    : string.Format(CultureInfo.InvariantCulture, "{0} {1}", pendingCalculation, currentNumber);
                firstNumber = intermediateResult;
                txtDisplay.Text = intermediateResult.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                firstNumber = currentNumber;
                pendingCalculation = firstNumber.ToString(CultureInfo.InvariantCulture);
            }

            currentOperator = operatorValue;
            isNewNumber = true;
            pendingCalculation = string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1}",
                pendingCalculation,
                currentOperator);
            lblPendingCalculation.Text = string.Format(
                CultureInfo.InvariantCulture,
                "{0}",
                pendingCalculation);
        }

        private bool TryCalculate(double leftNumber, string operatorValue, double rightNumber, out double result)
        {
            result = 0;

            switch (operatorValue)
            {
                case "+":
                    result = leftNumber + rightNumber;
                    return true;
                case "-":
                    result = leftNumber - rightNumber;
                    return true;
                case "*":
                    result = leftNumber * rightNumber;
                    return true;
                case "/":
                    if (rightNumber == 0)
                    {
                        return false;
                    }

                    result = leftNumber / rightNumber;
                    return true;
                default:
                    return false;
            }
        }

        private bool TryGetDisplayNumber(out double number)
        {
            return double.TryParse(txtDisplay.Text, CultureInfo.InvariantCulture, out number);
        }

        private void ShowError(string message)
        {
            txtDisplay.Text = message;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
            hasError = true;
            lblPendingCalculation.Text = "";
        }

        private void AddHistory(string calculation, double result)
        {
            string historyItem = string.Format(
                CultureInfo.InvariantCulture,
                "{0} = {1}",
                calculation,
                result);

            lstHistory.Items.Insert(0, historyItem);
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();
        }

        private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHistory.SelectedItem is not string historyItem)
            {
                return;
            }

            if (!TryGetHistoryResult(historyItem, out double result))
            {
                return;
            }

            txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
            firstNumber = 0;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
            hasError = false;
            lblPendingCalculation.Text = "";
        }

        private static bool TryGetHistoryResult(string historyItem, out double result)
        {
            result = 0;
            const string resultSeparator = " = ";
            int separatorIndex = historyItem.LastIndexOf(resultSeparator, StringComparison.Ordinal);

            if (separatorIndex < 0)
            {
                return false;
            }

            string resultText = historyItem[(separatorIndex + resultSeparator.Length)..];
            return double.TryParse(resultText, CultureInfo.InvariantCulture, out result);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
