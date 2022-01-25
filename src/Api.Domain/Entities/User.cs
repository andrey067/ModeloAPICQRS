using Api.Domain.Entities.ValeuObjects;
using Api.Domain.Entities.ValueObject;
using Api.Domain.Validators;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class User : BaseEntity
    {
        public Name Name { get; private set; }
        public string Occupation { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime DateRegister { get; private set; }
        public Email Email { get; private set; }
        public bool Verified { get; private set; }
        protected User() { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}