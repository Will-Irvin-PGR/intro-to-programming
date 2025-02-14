

namespace StringCalculator;
public class CalculatorTests
{

    private Calculator calculator = new Calculator(Substitute.For<ILogger>(), Substitute.For<IWebService>());
    [Fact]
    public void EmptyStringReturnsZero()
    {
        //var calculator = new Calculator();

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
        //var calculator = new Calculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1, 2", 3)]
    [InlineData("2, 3", 5)]
    [InlineData("3, 4", 7)]
    public void TwoDigits(string numbers, int expected)
    {
        //var calculator = new Calculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1, 2, 3", 6)]
    [InlineData("4, 5, 6, 7", 22)]
    [InlineData("1000, 54, 65, 2, 3", 1124)]
    public void ArbitraryDigits(string numbers, int expected)
    {
        //var calculator = new Calculator();

        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n 2, 3", 6)]
    [InlineData("4, 5\n 6, 7", 22)]
    [InlineData("1000, 54, 65\n 2, 3", 1124)]
    [InlineData("2\n 3", 5)]
    public void ArbitraryDelimiters(string numbers, int expected)
    {
        //var calculator = new Calculator();

        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\\1#2\n3", 6)]
    [InlineData("//b\\1b2b11", 14)]
    [InlineData("//a\\6a7\n3,2", 18)]
    public void CustomDelimiters(string numbers, int expected)
    {
        //var calculator = new Calculator();

        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\\-1#2\n-3")]
    [InlineData("//b\\1b-2b11")]
    [InlineData("//a\\6a-7\n3,2")]
    [InlineData("-1")]
    public void NegativeException(string numbers)
    {
        //var calculator = new Calculator();

        Assert.Throws<Exception>(() => calculator.Add(numbers));
    }
}
