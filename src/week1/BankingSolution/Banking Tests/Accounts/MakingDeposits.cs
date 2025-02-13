using Banking.Domain;
using Banking_Tests.TestDoubles;

namespace Banking_Tests.Accounts;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesBalance()
    {
        // Given
        var account = new Account(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.1M;


        // When 
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }


    [Fact]
    public void CannotMakeDepositWithNegativeNums()
    {
        var account = new Account(new DummyBonusCalculator());
        Assert.Throws<AccountNegativeTransactionException>(() => account.Deposit(-1));
    }
}
