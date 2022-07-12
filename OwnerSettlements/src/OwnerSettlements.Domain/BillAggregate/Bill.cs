using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using OwnerSettlements.Domain.Enums;
using OwnerSettlements.Domain.ValueObjects;

namespace OwnerSettlements.Domain
{
    public sealed class Bill : Entity<Guid>
    {
        private readonly ICollection<Settlement> _settlements;

        private decimal totalSettledAmount => _settlements.Sum(s => s.Amount);

        public decimal Amount { get; private set; }
        public BillMonth Period { get; private set; }
        public int OwnerId { get; private set; }
        public int MergeContractId { get; private set; }
        public IEnumerable<Settlement> Settlements =>
            _settlements.ToList();
        public bool IsPaid
        {
            get
            {
                return totalSettledAmount == Amount;
            }
        }

        public Bill(Guid id, decimal amount, BillMonth month, int ownerId, int mergeContracId)
        {
            this.Id = id;
            this.Amount = amount;
            this.Period = month;
            this.OwnerId = ownerId;
            this.MergeContractId = mergeContracId;
            _settlements = new List<Settlement>();
        }

        public decimal Settle(int paymentId, decimal availableAmount)
        {
            Guard.Against.NegativeOrZero(paymentId, nameof(paymentId));
            Guard.Against.NegativeOrZero(availableAmount, nameof(availableAmount));

            if (IsPaid)
                throw new Exception("This bill is already paid.");
            var settleAmount = GetSettleAmount(availableAmount);

            var settlement = new Settlement(this.Id, paymentId, settleAmount);
            _settlements.Add(settlement);

            return availableAmount - settleAmount;
        }

        private decimal GetSettleAmount(decimal availableAmount)
        {
            var pendingAmount = Amount - totalSettledAmount;
            return availableAmount > pendingAmount ? pendingAmount : availableAmount;
        }
    }
}
