using System.Globalization;

namespace SimpleCalculator
{
    public sealed class CalculatorEngine
    {
        private double firstNumber = 0;
        private string currentOperator = "";
        private string pendingCalculation = "";
        private bool isNewNumber = true;

        public string DisplayText { get; private set; } = "0";
        public string PendingCalculationText { get; private set; } = "";
        public bool HasError { get; private set; } = false;
        public bool CanCopyDisplayValue => !HasError && TryGetDisplayNumber(out _);

        public void PressNumber(string numberText)
        {
            if (HasError)
            {
                Clear();
            }

            if (DisplayText == "0" || isNewNumber)
            {
                DisplayText = numberText;
                isNewNumber = false;
            }
            else if (DisplayText == "-0")
            {
                DisplayText = "-" + numberText;
            }
            else
            {
                DisplayText += numberText;
            }
        }

        public void PressDecimal()
        {
            if (HasError)
            {
                Clear();
            }

            if (isNewNumber)
            {
                DisplayText = "0.";
                isNewNumber = false;
                return;
            }

            if (!DisplayText.Contains("."))
            {
                DisplayText += ".";
            }
        }

        public void ToggleSign()
        {
            if (HasError)
            {
                return;
            }

            if (DisplayText.StartsWith("-", StringComparison.Ordinal))
            {
                DisplayText = DisplayText[1..];
            }
            else
            {
                DisplayText = "-" + DisplayText;
            }

            isNewNumber = false;
        }

        public void Backspace()
        {
            if (HasError || isNewNumber)
            {
                return;
            }

            DisplayText = DisplayText.Length > 1 && DisplayText != "-0"
                ? DisplayText[..^1]
                : "0";

            if (DisplayText == "-" || DisplayText == "0")
            {
                DisplayText = "0";
                isNewNumber = true;
            }
        }

        public void ClearEntry()
        {
            DisplayText = "0";
            isNewNumber = true;
            HasError = false;
        }

        public void Clear()
        {
            DisplayText = "0";
            firstNumber = 0;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
            HasError = false;
            PendingCalculationText = "";
        }

        public void SetOperator(string operatorValue)
        {
            if (HasError)
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
                DisplayText = intermediateResult.ToString(CultureInfo.InvariantCulture);
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
            PendingCalculationText = pendingCalculation;
        }

        public string? PressEquals()
        {
            if (HasError || string.IsNullOrEmpty(currentOperator))
            {
                return null;
            }

            if (!TryGetDisplayNumber(out double secondNumber))
            {
                ShowError("Error: Invalid input");
                return null;
            }

            string historyCalculation = string.IsNullOrEmpty(pendingCalculation)
                ? string.Format(CultureInfo.InvariantCulture, "{0} {1} {2}", firstNumber, currentOperator, secondNumber)
                : string.Format(CultureInfo.InvariantCulture, "{0} {1}", pendingCalculation, secondNumber);

            if (!TryCalculate(firstNumber, currentOperator, secondNumber, out double result))
            {
                ShowError("Error: Cannot divide by zero");
                return null;
            }

            DisplayText = result.ToString(CultureInfo.InvariantCulture);
            PendingCalculationText = string.Format(CultureInfo.InvariantCulture, "{0} =", historyCalculation);
            firstNumber = result;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;

            return string.Format(CultureInfo.InvariantCulture, "{0} = {1}", historyCalculation, result);
        }

        public void LoadHistoryResult(double result)
        {
            DisplayText = result.ToString(CultureInfo.InvariantCulture);
            firstNumber = 0;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
            HasError = false;
            PendingCalculationText = "";
        }

        public static bool TryGetHistoryResult(string historyItem, out double result)
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

        private bool TryGetDisplayNumber(out double number)
        {
            return double.TryParse(DisplayText, CultureInfo.InvariantCulture, out number);
        }

        private void ShowError(string message)
        {
            DisplayText = message;
            currentOperator = "";
            pendingCalculation = "";
            isNewNumber = true;
            HasError = true;
            PendingCalculationText = "";
        }

        private static bool TryCalculate(double leftNumber, string operatorValue, double rightNumber, out double result)
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
    }
}
