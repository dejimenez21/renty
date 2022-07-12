using Xunit;
using OwnerSettlements.Domain;
using System;
using OwnerSettlements.Domain.ValueObjects;
using OwnerSettlements.Domain.Enums;
using System.Linq;
using FluentAssertions;

namespace OwnerSettlements.UnitTests.Domain.Entities.BillTests
{
    public class BillTests_Settle
    {
        [Theory]
        [InlineData(61206, 50000, 50000, 0, false)]
        [InlineData(61206, 61206, 61206, 0, true)]
        [InlineData(61206, 71206, 61206, 10000, true)]
        public void Settle_With_Unique_Settlement_Valid_Amount_Adds_Settlement_And_Returns_Change(
            decimal billAmount, 
            decimal inputSettleAmount,
            decimal expectedSettleAmount,
            decimal expectedChange,
            bool expectedIsPaid)
        {
            var paymentId = 10;
            var bill = CreateValidBillWithAmount(billAmount);
            var beforeSettleCount = bill.Settlements.Count();

            var actualChange = bill.Settle(paymentId, inputSettleAmount);

            bill.Settlements.Should().HaveCount(beforeSettleCount + 1);
            bill.Settlements.Should().Contain(s => s.Amount == expectedSettleAmount);
            bill.IsPaid.Should().Be(expectedIsPaid);
            actualChange.Should().Be(expectedChange);
        }


        private Bill CreateValidBillWithAmount(decimal amount) =>
            new Bill(Guid.NewGuid(), amount, new BillMonth(MonthEnum.March, 2021), 12, 1);
    }
}