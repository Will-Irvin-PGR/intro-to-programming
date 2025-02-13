namespace Banking.Domain;

public enum AccountTypes { Standard, Gold, Platinum }
public class Account
{
    private decimal _currentBalance = 5000;
    public AccountTypes AccountType = AccountTypes.Standard;

    public void Deposit(decimal amountToDeposit)
    {
        CheckTransactionAmount(amountToDeposit);
        decimal bonus = 0;
        if (AccountType == AccountTypes.Gold)
        {
            bonus = amountToDeposit * .2M;
        }
        _currentBalance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        CheckTransactionAmount(amountToWithdraw);

        if (_currentBalance >= amountToWithdraw)
        {
            _currentBalance -= amountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException();
        }
    }

    private static void CheckTransactionAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new AccountNegativeTransactionException();
        }
    }
}