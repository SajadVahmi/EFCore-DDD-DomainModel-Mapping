using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class StudentCourseId : ValueObject<StudentCourseId>
    {

        public Guid Value { get; private set; }
        public StudentCourseId() { Value = Guid.NewGuid(); }
        public StudentCourseId(Guid value) { Value = value; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
