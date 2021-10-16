using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Abstractions
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
       
        protected AggregateRoot() { }
        protected AggregateRoot(TKey id) : base(id)
        {
        }
       
    }
}
