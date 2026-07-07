using System.Globalization;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;
        private bool hasError = false;

        public Form1()
        {
            InitializeComponent();
            btnDecimal.Text = ".";
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            KeyPress += Form1_KeyPress;
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
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

        private void Form1_KeyPress(object? sender, KeyPressEventArgs e)
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

            string historyOperator = currentOperator;
            double result = 0;

            switch (historyOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        ShowError("Error: Cannot divide by zero");
                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;
            }

            txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
            AddHistory(firstNumber, historyOperator, secondNumber, result);
            currentOperator = "";
            isNewNumber = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void ResetCalculator()
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            currentOperator = "";
            isNewNumber = true;
            hasError = false;
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

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (hasError || isNewNumber)
            {
                return;
            }

            txtDisplay.Text = txtDisplay.Text.Length > 1
                ? txtDisplay.Text[..^1]
                : "0";

            if (txtDisplay.Text == "0")
            {
                isNewNumber = true;
            }
        }

        private void SetOperator(string operatorValue)
        {
            if (hasError)
            {
                return;
            }

            if (!TryGetDisplayNumber(out firstNumber))
            {
                ShowError("Error: Invalid input");
                return;
            }

            currentOperator = operatorValue;
            isNewNumber = true;
        }

        private bool TryGetDisplayNumber(out double number)
        {
            return double.TryParse(txtDisplay.Text, CultureInfo.InvariantCulture, out number);
        }

        private void ShowError(string message)
        {
            txtDisplay.Text = message;
            currentOperator = "";
            isNewNumber = true;
            hasError = true;
        }

        private void AddHistory(double leftNumber, string operatorValue, double rightNumber, double result)
        {
            string historyItem = string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1} {2} = {3}",
                leftNumber,
                operatorValue,
                rightNumber,
                result);

            lstHistory.Items.Insert(0, historyItem);
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
