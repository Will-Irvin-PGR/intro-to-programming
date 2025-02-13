using Banking.Domain;

namespace Banking_Tests.BonusCalculation;
public class StandardBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 20)]
    [InlineData(5000, 200, 40)]
    [InlineData(10000, 200, 40)]
    public void BonusesThatMeetThresholdGetBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(4999.99, 100, 0)]
    [InlineData(5, 100, 0)]
    [InlineData(0, 1000, 0)]
    public void BonusesBelowThresholdGetNoBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }
}
