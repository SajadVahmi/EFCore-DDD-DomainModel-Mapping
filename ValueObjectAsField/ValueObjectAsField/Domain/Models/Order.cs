using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectAsField.Domain.Models
{
    public class Order : AggregateRoot<OrderId>
    {
        public static Order Create()=>new Order();

        protected Order()
        {
            Id = OrderId.CreateWith(Guid.NewGuid());
            orderLines = new List<OrderLine>();

        }
        public Name Name { get; private set; }
        public Address Address { get; private set; }

        private List<OrderLine> orderLines;
        public IReadOnlyList<OrderLine> OrderLines => orderLines.AsReadOnly();

        public void SetAddress(string city, string street, int unit, string zipCode)
        {
            Address = Address.CreateWith(city, street, unit, zipCode);
        }
        public void SetName(string firstname, string lastname)
        {
            Name = Name.CreateWith(firstname, lastname);
        }

        public void AssignLines(List<OrderLine> orderLines)
        {
            this.orderLines = orderLines;
        }

        public void UpdateLines(List<OrderLine> orderLines)
        {
            var mustBeAdd = orderLines.Except(this.orderLines).ToList();
            var mustRemove = this.orderLines.Except(orderLines).ToList();

            mustBeAdd.ForEach(this.orderLines.Add);
            mustRemove.ForEach(item => this.orderLines.Remove(item));
        }

    }
}
