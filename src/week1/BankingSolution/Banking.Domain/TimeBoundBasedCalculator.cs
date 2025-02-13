namespace Banking.Domain;

public class TimeBoundBasedCalculator(IProvideTheBusinessClockForBonusCalculation _businessClock) : ICalculateBonusesForDepositsOnAccounts
{
    //private IProvideTheBusinessClockForBonusCalculation _businessClock;

    //public TimeBoundBasedCalculator(IProvideTheBusinessClockForBonusCalculation businessClock)
    //{
    //    _businessClock = businessClock;
    //}

    public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
    {
        if (_businessClock.CurrentlyDuringBusinessHours())
        {
            return balance >= 5000 ? depositAmount * .20M : 0;
        }
        else
        {
            return 0;
        }
    }


}

public interface IProvideTheBusinessClockForBonusCalculation
{
    bool CurrentlyDuringBusinessHours();
}