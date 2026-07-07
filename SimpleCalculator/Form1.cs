using System.Globalization;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;

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
            firstNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            currentOperator = "+";
            isNewNumber = true;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            firstNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            currentOperator = "-";
            isNewNumber = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            firstNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            currentOperator = "*";
            isNewNumber = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            firstNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            currentOperator = "/";
            isNewNumber = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(txtDisplay.Text, CultureInfo.InvariantCulture);
            double result = 0;

            switch (currentOperator)
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
                        txtDisplay.Text = "Cannot divide by zero";
                        isNewNumber = true;
                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;
            }

            txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
            isNewNumber = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            currentOperator = "";
            isNewNumber = true;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
