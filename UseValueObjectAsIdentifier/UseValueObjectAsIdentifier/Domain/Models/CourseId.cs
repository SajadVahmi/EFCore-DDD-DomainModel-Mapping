using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class CourseId : ValueObject<CourseId>
    {

        public Guid Value { get; private set; }
        public CourseId() { Value = Guid.NewGuid(); }
        public CourseId(Guid value){Value = value;}
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
