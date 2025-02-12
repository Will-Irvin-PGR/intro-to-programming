using Banking.Domain;

namespace Banking_Tests.Accounts;
public class MakingWithdrawals
{
    [Theory]
    [InlineData(42.23)]
    [InlineData(3.23)]
    [InlineData(5000)] // Can take full balance
    [InlineData(5000.01)] // Overdraft
    public void MakingWithdrawalsDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact (Skip = "Finish in morning")]
    public void OverdraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + .01M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
