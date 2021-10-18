using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseValueObjectAsIdentifier.Domain.Models
{
    public class Student:AggregateRoot<StudentId>
    {
        public static Student CreateWith(Guid id, string firstName, string lastName)
        {
            return new Student(id, firstName, lastName);
        }
        protected Student(Guid id,string firstName, string lastName)
        {
            Id = new StudentId(id);
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get;private set; }

    }
}
