using FluentAssertions;
using OwnerSettlements.Domain.Enums;
using OwnerSettlements.Domain.ValueObjects;
using Xunit;

namespace OwnerSettlements.UnitTests.Domain.ValueObjects.BillMonthTests
{
    public class BillMonthTests_Equality
    {
        [Fact]
        public void Equals_Returns_True_With_Equivalent_Bill_Months()
        {
            var inputMonth = MonthEnum.April;
            short inputYear = 2027;
            var billMonth = new BillMonth(inputMonth, inputYear);
            var otherBillMonth = new BillMonth(inputMonth, inputYear);

            var actualResult = billMonth.Equals(otherBillMonth);

            billMonth.Should().NotBeSameAs(otherBillMonth);
            actualResult.Should().BeTrue();
        }

        [Fact]
        public void Equals_Returns_False_When_Other_Is_Null()
        {
            var inputMonth = MonthEnum.April;
            short inputYear = 2027;
            var billMonth = new BillMonth(inputMonth, inputYear);
            BillMonth otherBillMonth = null;

            var actualResult = billMonth.Equals(otherBillMonth);

            actualResult.Should().BeFalse();
        }

        [Fact]
        public void Equals_Returns_False_When_Other_Is_Not_BillMonth()
        {
            var inputMonth = MonthEnum.April;
            short inputYear = 2027;
            var billMonth = new BillMonth(inputMonth, inputYear);
            var otherValueObject = new object();

            var actualResult = billMonth.Equals(otherValueObject);

            actualResult.Should().BeFalse();
        }

        [Fact]
        public void EqualityOperator_Returns_True_With_Equivalent_Bill_Months()
        {
            var inputMonth = MonthEnum.April;
            short inputYear = 2027;
            var billMonth = new BillMonth(inputMonth, inputYear);
            var otherBillMonth = new BillMonth(inputMonth, inputYear);

            var actualResult = (billMonth == otherBillMonth);

            billMonth.Should().NotBeSameAs(otherBillMonth);
            actualResult.Should().BeTrue();
        }

        [Fact]
        public void EqualityOperator_Returns_True_When_Both_Null()
        {
            BillMonth billMonth = null;
            BillMonth otherBillMonth = null;

            var actualResult = (billMonth == otherBillMonth);

            actualResult.Should().BeTrue();
        }

        [Fact]
        public void EqualityOperator_Returns_False_With_Equivalent_Bill_Months()
        {
            var inputMonth = MonthEnum.April;
            short inputYear = 2027;
            var billMonth = new BillMonth(inputMonth, inputYear);
            var otherBillMonth = new BillMonth(inputMonth, inputYear);

            var actualResult = (billMonth == otherBillMonth);

            actualResult.Should().BeTrue();
        }

        [Fact]
        public void InequalityOperator_Returns_True_With_Equivalent_Bill_Months()
        {
            var inputMonth = MonthEnum.April;
            short inputYear = 2027;
            var billMonth = new BillMonth(inputMonth, inputYear);
            var otherBillMonth = new BillMonth(inputMonth, inputYear);

            var actualResult = (billMonth != otherBillMonth);

            actualResult.Should().BeFalse();
        }
    }
}
