using Banking.Domain;

namespace Banking_Tests.Accounts;
public class MakingWithdrawals
{
    [Fact]
    public void MakingWithdrawalsDecreasesTheBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 42.23M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}
