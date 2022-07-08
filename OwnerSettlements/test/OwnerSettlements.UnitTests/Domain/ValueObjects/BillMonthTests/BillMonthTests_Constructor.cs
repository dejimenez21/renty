using Xunit;
using OwnerSettlements.Domain.Enums;
using OwnerSettlements.Domain.ValueObjects;
using FluentAssertions;
using System;

namespace OwnerSettlements.UnitTests.Domain.ValueObjects.BillMonthTests
{
    public partial class BillMonthTests_Constructor
    {
        [Fact]
        public void CreateBillMonth_Doesnt_Throw_Exception()
        {
            //given
            var month = MonthEnum.March;
            short year = 2021;

            //when
            var billMonthCreation = () => new BillMonth(month, year);
            var actualBillMonth = billMonthCreation();

            //then
            billMonthCreation.Should().NotThrow();
            actualBillMonth.Month.Should().Be(month);
            actualBillMonth.Year.Should().Be(year);
        }

        [Fact]
        public void CreateBillMonth_With_Date_Doesnt_Throw_Exception()
        {
            //given
            var inputDate = new DateTime(2021, 03, 05);
            var expectedBillMonth = new BillMonth(MonthEnum.March, 2021);

            //when
            var actualBillMonth = new BillMonth(inputDate);

            //then
            actualBillMonth.Month.Should().Be(expectedBillMonth.Month);
            actualBillMonth.Year.Should().Be(expectedBillMonth.Year);

        }
    }
}