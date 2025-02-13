using Banking.Domain;
using Banking_Tests.TestDoubles;

namespace Banking_Tests.Accounts.GoldAccounts;
public class GetBonusOnDeposits
{
    [Fact]
    public void GetBonus()
    {
        var account = new Account(new StubbedBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var expectedBonus = 20M;
        var expectedNewBalance = openingBalance + amountToDeposit + expectedBonus;
        account.Deposit(amountToDeposit);

        Assert.Equal(expectedNewBalance, account.GetBalance());
    }
}

public class StubbedBonusCalculator : ICalculateBonusesForDepositsOnAccounts
{
    public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
    {
        if (balance == 5000M && depositAmount == 100M) return 20M;
        else return 0;
    }
}
