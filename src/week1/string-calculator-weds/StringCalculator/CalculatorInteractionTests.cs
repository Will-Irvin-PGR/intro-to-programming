namespace StringCalculator;
public class CalculatorInteractionTests
{
    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("123")]
    public void CallsLoggerWithResult(string numbers)
    {
        var mockedLogger = Substitute.For<ILogger>();
        var mockedWebService = Substitute.For<IWebService>();
        var calculator = new Calculator(mockedLogger, mockedWebService);

        calculator.Add(numbers);

        // 1 arg specifies number of times it should be called
        mockedLogger.Received(1).Write(numbers);
        mockedWebService.DidNotReceive().NotifyOfLoggingFailure(Arg.Any<string>());
    }

    [Theory]
    [InlineData("1", "Log Failure Detected")]
    public void WhenTheLoggerFailsCallAWebServiceToReportIt(string numbers, string message)
    {
        var stubbedLogger = Substitute.For<ILogger>();
        var stubbedService = Substitute.For<IWebService>();
        stubbedLogger.When(c => c.Write(Arg.Any<string>())).Throw(new Exception(message));
        var calculator = new Calculator(stubbedLogger, stubbedService);

        calculator.Add(numbers);

        stubbedService.Received(1).NotifyOfLoggingFailure(message);
    }
}
