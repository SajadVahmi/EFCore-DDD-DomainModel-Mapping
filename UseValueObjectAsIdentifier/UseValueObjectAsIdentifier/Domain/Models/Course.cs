using Framework.Domain.Abstractions;
using System;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class Course : AggregateRoot<CourseId>
    {
        public static Course CreateWith(Guid id, string name, int unit)
        {
            return new Course(id, name, unit);
        }
        protected Course() { }
        protected Course(Guid id, string name, int unit
            )
        {
            Id = new CourseId(id);
            Name = name;
            Unit = unit;
        }

        public string Name { get; private set; }
        public int Unit { get; private set; }

    }
}
