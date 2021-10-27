using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectAsField.Domain.Models
{
    public class OrderId : ValueObject<OrderId>
    {
        public static OrderId Create() => new OrderId();
        public static OrderId CreateWith(Guid value) => new OrderId(value);
        protected OrderId(){ this.Value = Guid.NewGuid(); }
        protected OrderId(Guid value) 
        {
            if (value == default(Guid))
                throw new ArgumentException("Id can not be default guid.");
            this.Value = value; 
        }
        public Guid Value { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
