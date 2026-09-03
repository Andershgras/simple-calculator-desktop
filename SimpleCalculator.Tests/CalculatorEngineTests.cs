namespace SimpleCalculator.Tests;

public class CalculatorEngineTests
{
    [Fact]
    public void PressEquals_AddsNumbers()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "2");
        calculator.SetOperator("+");
        Enter(calculator, "3");
        string? historyItem = calculator.PressEquals();

        Assert.Equal("5", calculator.DisplayText);
        Assert.Equal("2 + 3 =", calculator.PendingCalculationText);
        Assert.Equal("2 + 3 = 5", historyItem);
    }

    [Fact]
    public void PressEquals_SubtractsNumbers()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "9");
        calculator.SetOperator("-");
        Enter(calculator, "4");
        calculator.PressEquals();

        Assert.Equal("5", calculator.DisplayText);
    }

    [Fact]
    public void PressEquals_MultipliesNumbers()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "6");
        calculator.SetOperator("*");
        Enter(calculator, "7");
        calculator.PressEquals();

        Assert.Equal("42", calculator.DisplayText);
    }

    [Fact]
    public void PressEquals_DividesNumbers()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "8");
        calculator.SetOperator("/");
        Enter(calculator, "2");
        calculator.PressEquals();

        Assert.Equal("4", calculator.DisplayText);
    }

    [Fact]
    public void PressEquals_CalculatesDecimalValues()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "1.5");
        calculator.SetOperator("+");
        Enter(calculator, "2.25");
        calculator.PressEquals();

        Assert.Equal("3.75", calculator.DisplayText);
    }

    [Fact]
    public void PressDecimal_PreventsMultipleDecimalPoints()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "1.2.3");

        Assert.Equal("1.23", calculator.DisplayText);
    }

    [Fact]
    public void PressEquals_DivisionByZeroShowsError()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "8");
        calculator.SetOperator("/");
        Enter(calculator, "0");
        string? historyItem = calculator.PressEquals();

        Assert.Null(historyItem);
        Assert.True(calculator.HasError);
        Assert.False(calculator.CanCopyDisplayValue);
        Assert.Equal("Error: Cannot divide by zero", calculator.DisplayText);
        Assert.Equal("", calculator.PendingCalculationText);
    }

    [Fact]
    public void SetOperator_DivisionByZeroInChainedCalculationShowsError()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "8");
        calculator.SetOperator("/");
        Enter(calculator, "0");
        calculator.SetOperator("+");

        Assert.True(calculator.HasError);
        Assert.Equal("Error: Cannot divide by zero", calculator.DisplayText);
    }

    [Fact]
    public void Clear_ResetsFullCalculation()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "12");
        calculator.SetOperator("+");
        Enter(calculator, "3");
        calculator.Clear();

        Assert.Equal("0", calculator.DisplayText);
        Assert.Equal("", calculator.PendingCalculationText);
        Assert.False(calculator.HasError);
        Assert.Null(calculator.PressEquals());
    }

    [Fact]
    public void ClearEntry_ClearsOnlyCurrentNumber()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "12");
        calculator.SetOperator("+");
        Enter(calculator, "99");
        calculator.ClearEntry();
        Enter(calculator, "3");
        calculator.PressEquals();

        Assert.Equal("15", calculator.DisplayText);
    }

    [Fact]
    public void Backspace_RemovesCurrentInputDigits()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "123");
        calculator.Backspace();

        Assert.Equal("12", calculator.DisplayText);
    }

    [Fact]
    public void Backspace_ReturnsSingleDigitInputToZero()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "7");
        calculator.Backspace();

        Assert.Equal("0", calculator.DisplayText);
    }

    [Fact]
    public void PressEquals_SupportsChainedCalculations()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "2");
        calculator.SetOperator("+");
        Enter(calculator, "3");
        calculator.SetOperator("+");
        Enter(calculator, "4");
        string? historyItem = calculator.PressEquals();

        Assert.Equal("9", calculator.DisplayText);
        Assert.Equal("2 + 3 + 4 = 9", historyItem);
    }

    [Fact]
    public void ToggleSign_CanCreateNegativeNumbers()
    {
        CalculatorEngine calculator = new();

        Enter(calculator, "5");
        calculator.ToggleSign();
        calculator.SetOperator("*");
        Enter(calculator, "3");
        calculator.PressEquals();

        Assert.Equal("-15", calculator.DisplayText);
    }

    [Fact]
    public void LoadHistoryResult_CanBeUsedInNewCalculation()
    {
        CalculatorEngine calculator = new();

        calculator.LoadHistoryResult(15);
        calculator.SetOperator("+");
        Enter(calculator, "5");
        calculator.PressEquals();

        Assert.Equal("20", calculator.DisplayText);
    }

    private static void Enter(CalculatorEngine calculator, string input)
    {
        foreach (char character in input)
        {
            if (character == '.')
            {
                calculator.PressDecimal();
            }
            else
            {
                calculator.PressNumber(character.ToString());
            }
        }
    }
}
