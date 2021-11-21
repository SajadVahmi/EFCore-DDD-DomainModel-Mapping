using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectAsField.Domain.Models
{
    public class OrderLine : ValueObject<OrderLine>
    {
        public static OrderLine CreateWith(int productId, int quantity, long eachPrice) 
            => new OrderLine(productId, quantity, eachPrice);
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public long EachPrice { get; private set; }
        public long Price => Quantity * EachPrice;
        protected OrderLine() { }
        protected OrderLine(int productId, int quantity, long eachPrice)
        {
            if(productId is default(int) || quantity is default(int)) 
                throw new ArgumentException("The productId and quantity are required.");
            ProductId = productId;
            Quantity = quantity;
            EachPrice = eachPrice;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.ProductId;
            yield return this.Quantity;
            yield return this.EachPrice;
        }
    }
}
