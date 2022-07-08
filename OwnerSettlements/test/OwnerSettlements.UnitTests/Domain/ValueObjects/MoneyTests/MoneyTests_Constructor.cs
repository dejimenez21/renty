using FluentAssertions;
using OwnerSettlements.Domain.ValueObjects;
using System;
using Xunit;

namespace OwnerSettlements.UnitTests.Domain.ValueObjects.MoneyTests
{
    public class MoneyTests_Constructor
    {
        [Fact]
        public void MoneyCreation_Creates_Valid_Instance()
        {
            var inputDopAmount = 42142.12M;
            var inputUsdAmount = 769.58M;

            var moneyCreation = () => new Money(inputDopAmount, inputUsdAmount);
            var actualMoney = moneyCreation();

            moneyCreation.Should().NotThrow<Exception>();
            actualMoney.DopAmount.Should().Be(inputDopAmount);
            actualMoney.UsdAmount.Should().Be(inputUsdAmount);
            actualMoney.DollarExchangeRate.Should().Be(inputDopAmount / inputUsdAmount);
        }

        [Theory]
        [InlineData(0, 12.4)]
        [InlineData(0, 0)]
        [InlineData(0, -12.4)]
        [InlineData(-23, 12.4)]
        [InlineData(-15.4, 0)]
        [InlineData(-12.4, 12.4)]
        [InlineData(123.5, -12.4)]
        [InlineData(123.5, 0)]
        public void MoneyCreation_With_Negative_Or_Zero_Amount_Or_DollarExchangeRate_Throws_ArgumentException(decimal inputAmount, decimal inputDollarExchangeRate)
        {
            var moneyCreation = () => new Money(inputAmount, inputDollarExchangeRate);

            moneyCreation.Should().Throw<ArgumentException>();
        }
    }
}
