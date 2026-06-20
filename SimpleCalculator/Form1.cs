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
            firstNumber = double.Parse(txtDisplay.Text);
            currentOperator = "+";
            isNewNumber = true;
        }
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            firstNumber = double.Parse(txtDisplay.Text);
            currentOperator = "-";
            isNewNumber = true;
        }
        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(txtDisplay.Text);

            double result = 0;

            if (currentOperator == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (currentOperator == "-")
            {
                result = firstNumber - secondNumber;
            }

            txtDisplay.Text = result.ToString();
            isNewNumber = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
