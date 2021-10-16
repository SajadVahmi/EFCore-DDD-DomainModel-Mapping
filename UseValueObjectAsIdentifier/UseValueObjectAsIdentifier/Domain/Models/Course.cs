using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class Course : AggregateRoot<CourseId>
    {
        public Course(CourseId id,string name, int unit
            )
        {
            Id = id;
            Name = name;
            Unit = unit;
        }

        public string Name { get; private set; }
        public int Unit { get; private set; }
        
    }
}
