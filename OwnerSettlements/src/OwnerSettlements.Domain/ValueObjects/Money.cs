using Ardalis.GuardClauses;

namespace OwnerSettlements.Domain.ValueObjects
{
    public sealed class Money : ValueObject
    {
        public decimal DopAmount { get; }
        public decimal UsdAmount { get; }

        public decimal DollarExchangeRate => DopAmount / UsdAmount;

        public Money(decimal dop, decimal usd)
        {
            this.DopAmount = Guard.Against.NegativeOrZero(dop);
            this.UsdAmount = Guard.Against.NegativeOrZero(usd);
        }

        public static Money operator +(Money aMoney, Money bMoney)
        {
            var resultDopAmount = aMoney.DopAmount + bMoney.DopAmount;
            var resultUsdAmount = aMoney.UsdAmount + bMoney.UsdAmount;

            return new Money(resultDopAmount, resultUsdAmount);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(DopAmount, 2);
            yield return Math.Round(UsdAmount, 2);
        }
    }
}