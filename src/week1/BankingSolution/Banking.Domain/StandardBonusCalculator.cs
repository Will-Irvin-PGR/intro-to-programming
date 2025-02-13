
namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateBonusesForDepositsOnAccounts
{
    public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
    {
        return balance >= 5000 ? depositAmount * .20M : 0;
    }
}