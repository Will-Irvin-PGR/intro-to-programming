﻿

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("1000", 1000)]
    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
