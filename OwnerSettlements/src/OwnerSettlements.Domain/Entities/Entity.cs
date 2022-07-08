using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerSettlements.Domain
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }

        //public override bool Equals(Entity<TKey> other)
        //{
        //    return this.Id == other.Id;
        //}
    }
}
