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
        public Guid BillId { get; set; }
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }

        public Settlement(Guid billId, int paymentId, decimal amount)
        {
            BillId = billId;
            PaymentId = paymentId;
            Amount = amount;
        }

        private Settlement() { }

    }
}
