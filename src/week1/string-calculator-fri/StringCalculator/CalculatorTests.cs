

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

    [Theory]
    [InlineData("1,2, 3", 6)]
    [InlineData("2,4,10,11", 27)]
    [InlineData("3,7,100,20", 130)]
    [InlineData("429,51,1,3,4", 488)]
    public void ArbitraryIntegers(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2\n3", 6)]
    [InlineData("2\n4,10,11", 27)]
    [InlineData("3,7,100\n20", 130)]
    [InlineData("429,51\n1\n3,4", 488)]
    public void NewLineDelimiter(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
