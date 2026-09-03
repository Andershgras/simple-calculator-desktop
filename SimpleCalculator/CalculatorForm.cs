namespace SimpleCalculator
{
    public partial class CalculatorForm : Form
    {
        private const int MaxHistoryItems = 50;
        private static readonly string HistoryDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SimpleCalculator");
        private static readonly string HistoryFilePath = Path.Combine(HistoryDirectory, "history.txt");

        private readonly CalculatorEngine calculator = new();

        public CalculatorForm()
        {
            InitializeComponent();
            btnDecimal.Text = ".";
            KeyPreview = true;
            KeyDown += CalculatorForm_KeyDown;
            KeyPress += CalculatorForm_KeyPress;
            FormClosing += CalculatorForm_FormClosing;
            LoadHistory();
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
            Button button = (Button)sender;
            calculator.PressNumber(button.Text);
            UpdateDisplay();
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
            string? historyItem = calculator.PressEquals();
            UpdateDisplay();
            if (historyItem is not null)
            {
                AddHistoryItem(historyItem);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
            UpdateDisplay();
        }

        private void ResetCalculator()
        {
            calculator.Clear();
            UpdateDisplay();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            calculator.PressDecimal();
            UpdateDisplay();
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {
            calculator.ToggleSign();
            UpdateDisplay();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            calculator.Backspace();
            UpdateDisplay();
        }

        private void CopyDisplayValueToClipboard()
        {
            if (!calculator.CanCopyDisplayValue)
            {
                return;
            }

            try
            {
                Clipboard.SetText(calculator.DisplayText);
            }
            catch
            {
            }
        }

        private void SetOperator(string operatorValue)
        {
            calculator.SetOperator(operatorValue);
            UpdateDisplay();
        }

        private void AddHistoryItem(string historyItem)
        {
            lstHistory.Items.Insert(0, historyItem);
            TrimHistory();
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();
            DeleteSavedHistory();
        }

        private void CalculatorForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveHistory();
        }

        private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHistory.SelectedItem is not string historyItem)
            {
                return;
            }

            if (!CalculatorEngine.TryGetHistoryResult(historyItem, out double result))
            {
                return;
            }

            calculator.LoadHistoryResult(result);
            UpdateDisplay();
        }

        private void LoadHistory()
        {
            try
            {
                if (!File.Exists(HistoryFilePath))
                {
                    return;
                }

                foreach (string historyItem in File.ReadLines(HistoryFilePath).Take(MaxHistoryItems))
                {
                    if (CalculatorEngine.TryGetHistoryResult(historyItem, out _))
                    {
                        lstHistory.Items.Add(historyItem);
                    }
                }
            }
            catch
            {
                lstHistory.Items.Clear();
            }
        }

        private void SaveHistory()
        {
            try
            {
                Directory.CreateDirectory(HistoryDirectory);
                File.WriteAllLines(
                    HistoryFilePath,
                    lstHistory.Items
                        .OfType<string>()
                        .Where(historyItem => CalculatorEngine.TryGetHistoryResult(historyItem, out _))
                        .Take(MaxHistoryItems));
            }
            catch
            {
            }
        }

        private void DeleteSavedHistory()
        {
            try
            {
                if (File.Exists(HistoryFilePath))
                {
                    File.Delete(HistoryFilePath);
                }
            }
            catch
            {
            }
        }

        private void TrimHistory()
        {
            while (lstHistory.Items.Count > MaxHistoryItems)
            {
                lstHistory.Items.RemoveAt(lstHistory.Items.Count - 1);
            }
        }

        private void UpdateDisplay()
        {
            txtDisplay.Text = calculator.DisplayText;
            lblPendingCalculation.Text = calculator.PendingCalculationText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
