using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class StudentId : ValueObject<StudentId>
    {
        public StudentId() { Value = Guid.NewGuid(); }
        public StudentId(Guid value){Value = value;}
       
        public Guid Value { get;private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.Value;
        }
    }
}
