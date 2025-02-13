using Banking.Domain;
using Banking_Tests.TestDoubles;
using NSubstitute;

namespace Banking_Tests.Accounts;
public class NewAccounts
{
    [Fact]
    public void BalanceIsCorrect()
    {
        var correctOpeningBalance = 5000M;

        var myAccount = new Account(Substitute.For<ICalculateBonusesForDepositsOnAccounts>());
        var yourAccount = new Account(new DummyBonusCalculator());

        Assert.Equal(correctOpeningBalance, myAccount.GetBalance());
        Assert.Equal(correctOpeningBalance, yourAccount.GetBalance());
    }
}
