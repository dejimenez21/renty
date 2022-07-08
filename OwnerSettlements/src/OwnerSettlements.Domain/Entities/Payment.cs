using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OwnerSettlements.Domain.Enums;
using OwnerSettlements.Domain.ValueObjects;

namespace OwnerSettlements.Domain
{
    public class Payment : Entity<int>
    {
        [Column(TypeName = "decimal(12,2)")]
        [Required]
        public Money Amount { get; set; }
        public CurrencyEnum DeliveryCurrency { get; } 

        [Required]
        public string DeliveredBy { get; set; }
        public bool Confirmed { get; set; } = false;
        public string Comment { get; set; }
        [Required]
        public DateTime SentAt { get; set; }
        public int OwnerId { get; set; }
    }
}