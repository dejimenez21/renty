using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OwnerSettlements.Domain.Enums;
using OwnerSettlements.Domain.ValueObjects;

namespace OwnerSettlements.Domain
{
    public sealed class Bill : Entity<Guid>
    {
        private readonly ICollection<Settlement> _settlements;

        public Money Amount { get; }
        public BillMonth Month { get; }        
        public int OwnerId { get; }
        public int MergeContractId { get; }
        public IEnumerable<Settlement> Settlements =>
            _settlements.ToList();

        public Bill(Guid id, Money amount, BillMonth month, int ownerId, int mergeContracId)
        {
            this.Id = id;
            this.Amount = amount;
            this.Month = month;
            this.OwnerId = ownerId;
            this.MergeContractId = mergeContracId;
            _settlements = new List<Settlement>();
        }

        public void Settle(Settlement settlement)
        {
            if (settlement.PaymentApplied.OwnerId != this.OwnerId)
                throw new Exception("The payments owner and the bill owner must be the same");

            _settlements.Add(settlement);  
        }
    }
}
