using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OwnerSettlements.Domain.Enums;
using OwnerSettlements.Domain.ValueObjects;

namespace OwnerSettlements.Domain
{
    public class Payment : Entity<int>
    {
        public Money Amount { get; set; }
        public CurrencyEnum DeliveryCurrency { get; } 
        public string DeliveredBy { get; set; }
        public bool Confirmed { get; set; } = false;
        public string Comment { get; set; }
        public DateTime SentAt { get; set; }
        public int OwnerId { get; set; }
    }
}