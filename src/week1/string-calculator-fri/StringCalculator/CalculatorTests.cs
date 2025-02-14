

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
}
