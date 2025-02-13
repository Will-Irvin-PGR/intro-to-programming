using Banking.Domain;

namespace Banking_Tests.Accounts;
public class MakingWithdrawals
{
    [Theory]
    [InlineData(42.23)]
    [InlineData(3.23)]
    public void MakingWithdrawalsDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void CannotMakeWithdrawalWithNegativeNum()
    {
        var account = new Account();
        Assert.Throws<AccountNegativeTransactionException>(() => account.Withdraw(-3));
    }

    [Fact]
    public void CanWithdrawFullBalance()
    {
        var account = new Account();

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }

    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + .01M;

        Assert.Throws<AccountOverdraftException>(() => account.Withdraw(amountToWithdraw));
    }
}
