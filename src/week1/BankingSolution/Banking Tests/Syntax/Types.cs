namespace Banking_Tests.Syntax;
public class Types
{
    string Name = "Bob";

    [Fact]
    public void DeclaringVariables()
    {
        var age = 55;

        var yourAge = 16.5;

        var myHourlyPay = 18.23M;

        Assert.Equal(55, age);

        Assert.Equal("Bob", Name);
    }

    [Fact]
    public void AnotherThing()
    {
        Assert.Equal("Bob", this.Name);
    }
}
