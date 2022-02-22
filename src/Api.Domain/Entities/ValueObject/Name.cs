using System;

namespace Api.Domain.Entities.ValueObject
{
    public sealed class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}