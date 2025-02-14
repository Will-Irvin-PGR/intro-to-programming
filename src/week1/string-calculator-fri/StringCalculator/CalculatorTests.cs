﻿

namespace StringCalculator;
public class CalculatorTests
{
    private Calculator calculator = new Calculator();
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("429", 429)]
    public void SingleInteger(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,4", 6)]
    [InlineData("3,7", 10)]
    [InlineData("429,51", 480)]
    public void TwoIntegers(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
