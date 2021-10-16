using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseValueObjectAsIdentifier.Domain.Models;

namespace UseValueObjectAsIdentifier.Domain
{
    public class Student:AggregateRoot<StudentId>
    {
        public Student(StudentId id,string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get;private set; }

    }
}
