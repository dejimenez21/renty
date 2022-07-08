using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerSettlements.Domain
{
    public class Settlement : Entity<int>
    {
        public int InvoiceId { get; set; }
        public int PaymentId { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; set; }

        [ForeignKey("InvoiceId")]
        public Bill BillPaid { get; set; }
        [ForeignKey("PaymentId")]
        public Payment PaymentApplied { get; set; }
    }
}
