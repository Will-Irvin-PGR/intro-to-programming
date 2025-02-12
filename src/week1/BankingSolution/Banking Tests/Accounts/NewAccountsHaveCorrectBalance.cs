using Banking.Domain;

namespace Banking_Tests.Accounts;
public class NewAccountsHaveCorrectBalance
{
    [Fact]
    public void BalanceIsCorrect()
    {
        var correctOpeningBalance = 5000M;

        var myAccount = new Account();
        var yourAccount = new Account();

        Assert.Equal(correctOpeningBalance, myAccount.GetBalance());
        Assert.Equal(correctOpeningBalance, yourAccount.GetBalance());
    }
}
