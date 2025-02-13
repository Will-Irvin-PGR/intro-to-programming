using Banking.Domain;
using NSubstitute;

namespace Banking_Tests.BonusCalculation;
public class TimeBasedBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 20)]
    [InlineData(5000, 200, 40)]
    [InlineData(10000, 200, 40)]
    public void BonusesThatMeetThresholdInBusinessHoursGetBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var stubbedBusinessClock = Substitute.For<IProvideTheBusinessClockForBonusCalculation>();
        
        var bonusCalculator = new TimeBoundBasedCalculator(stubbedBusinessClock);

        stubbedBusinessClock.CurrentlyDuringBusinessHours().Returns(true);
        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(5000, 100, 0)]
    [InlineData(5000, 200, 0)]
    [InlineData(10000, 200, 0)]
    public void BonusesThatMeetThresholdOutsideBusinessHoursGetNoBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var stubbedBusinessClock = Substitute.For<IProvideTheBusinessClockForBonusCalculation>();

        var bonusCalculator = new TimeBoundBasedCalculator(stubbedBusinessClock);

        stubbedBusinessClock.CurrentlyDuringBusinessHours().Returns(false);

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(4999.99, 100, 0)]
    [InlineData(5, 100, 0)]
    [InlineData(0, 1000, 0)]
    public void BonusesBelowThresholdGetNoBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var stubbedBusinessClock = Substitute.For<IProvideTheBusinessClockForBonusCalculation>();

        var bonusCalculator = new TimeBoundBasedCalculator(stubbedBusinessClock);

        stubbedBusinessClock.CurrentlyDuringBusinessHours().Returns(true);

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }
}
