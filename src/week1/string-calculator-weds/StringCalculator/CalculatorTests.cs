

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

    [Theory]
    [InlineData("1, 2", 3)]
    [InlineData("2, 3", 5)]
    [InlineData("3, 4", 7)]
    public void TwoDigits(string numbers, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1, 2, 3", 6)]
    [InlineData("4, 5, 6, 7", 22)]
    [InlineData("1000, 54, 65, 2, 3", 1124)]
    public void ArbitraryDigits(string numbers, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
}
