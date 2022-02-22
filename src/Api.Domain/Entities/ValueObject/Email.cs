using System;

namespace Api.Domain.Entities.ValeuObjects
{
    public sealed class Email
    {
        public Email(string address)
        {
            Address = address;
            Validate();
        }

        public string Address { get; private set; }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}