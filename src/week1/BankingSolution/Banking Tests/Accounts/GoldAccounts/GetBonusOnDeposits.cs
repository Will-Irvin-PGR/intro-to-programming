using Banking.Domain;

namespace Banking_Tests.Accounts.GoldAccounts;
public class GetBonusOnDeposits
{
    [Fact]
    public void GetBonus()
    {
        var account = new GoldAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var expectedBonus = 20M;
        var expectedNewBalance = openingBalance + amountToDeposit + expectedBonus;
        account.Deposit(amountToDeposit);

        Assert.Equal(expectedNewBalance, account.GetBalance());
    }
}
