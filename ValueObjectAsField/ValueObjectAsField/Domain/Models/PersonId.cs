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
        public static PersonId Create() => new PersonId();
        public static PersonId CreateWith(Guid value) => new PersonId(value);
        protected PersonId(){ this.Value = Guid.NewGuid(); }
        protected PersonId(Guid value) 
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
