using FluentAssertions;
using OwnerSettlements.Domain.ValueObjects;
using Xunit;

namespace OwnerSettlements.UnitTests.Domain.ValueObjects.MoneyTests
{
    public class MoneyTests_Equality
    {
        [Fact]
        public void Equals_Return_True_Rounded_Two_Decimals()
        {
            var inputDopAmount = 1200.23424M;
            var inputUsdAmount = 21.56634M;
            var otherInputDopAmount = 1200.23M;
            var otherInputUsdAmount = 21.57M;

            var money = new Money(dop: inputDopAmount, usd: inputUsdAmount);
            var otherMoney = new Money(dop: otherInputDopAmount, usd: otherInputUsdAmount);

            money.Should().Be(otherMoney);
        }
    }
}
