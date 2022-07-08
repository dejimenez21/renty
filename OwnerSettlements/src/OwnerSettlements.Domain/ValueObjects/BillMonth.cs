using OwnerSettlements.Domain.Enums;

namespace OwnerSettlements.Domain.ValueObjects
{
    public class BillMonth : ValueObject
    {
        public MonthEnum Month { get; }
        public short Year { get; }

        public BillMonth(MonthEnum month, short year)
        {
            this.Month = month;
            this.Year = year;
        }

        public BillMonth(DateTime date) : this((MonthEnum)date.Month, (short)date.Year) { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Month;
            yield return Year;
        }
    }
}