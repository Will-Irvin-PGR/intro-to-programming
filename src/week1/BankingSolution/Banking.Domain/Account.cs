﻿namespace Banking.Domain;

public enum AccountTypes { Standard, Gold, Platinum }
public class Account
{
    private decimal _currentBalance = 5000;
    private ICalculateBonusesForDepositsOnAccounts _bonusCalculator;

    public Account(ICalculateBonusesForDepositsOnAccounts bonusCalculator)
    {
        _currentBalance = 5000;
        _bonusCalculator = bonusCalculator;
    }

    public virtual void Deposit(decimal amountToDeposit)
    {

        CheckTransactionAmount(amountToDeposit);
        _currentBalance += amountToDeposit + _bonusCalculator.CalculateBonusForDeposit(_currentBalance, amountToDeposit);
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