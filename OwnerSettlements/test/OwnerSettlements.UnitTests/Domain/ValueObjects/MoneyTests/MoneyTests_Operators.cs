using FluentAssertions;
using OwnerSettlements.Domain.ValueObjects;
using Xunit;

namespace OwnerSettlements.UnitTests.Domain.ValueObjects.MoneyTests
{
    public class MoneyTests_Operators
    {
        [Fact]
        public void SumOperator_Returns_New_Money_With_The_Sum_Of_Each_Property()
        {
            var aDopAmount = 12000.57M;
            var aUsdAmount = 212.13M;
            var bDopAmount = 1000.57M;
            var bUsdAmount = 18.13M;
            var aMoney = new Money(aDopAmount, aUsdAmount);
            var bMoney = new Money(bDopAmount, bUsdAmount);
            var expectedMoney = new Money(aDopAmount + bDopAmount, aUsdAmount + bUsdAmount);

            var actualMoney = aMoney + bMoney;

            actualMoney.Should().Be(expectedMoney);
        }
    }
}
