using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ValueObjectAsField.Domain.Models
{
    public class Name : ValueObject<Name>
    {
        public static Name CreateWith(string firstname, string lastname)
        {
            return new Name(firstname, lastname);
        }
        protected Name(string firstname, string lastname)
        {
            if (String.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
                throw new Exception("The firstname and lastname are required.");
            Firstname = firstname;
            Lastname = lastname;
        }

        public Name ChangeWith(string firstname, string lastname)
        {
            return new Name(firstname, lastname);
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Firstname;
            yield return Lastname;
        }
    }
}
