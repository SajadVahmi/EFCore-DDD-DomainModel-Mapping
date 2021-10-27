using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectAsField.Domain.Models
{
    public class PersonId : ValueObject<PersonId>
    {
        public PersonId(){ this.Value = Guid.NewGuid(); }
        public PersonId(Guid value) { this.Value = value; }
        public Guid Value { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
