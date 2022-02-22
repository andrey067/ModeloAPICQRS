using System;
using Api.Domain.Entities.ValueObject;
using Api.Domain.Entities.ValeuObjects;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public Name Name { get; private set; }
        public string Occupation { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime DateRegister { get; private set; }
        public Email Email { get; private set; }
        public bool Verified { get; private set; }
        protected UserEntity() { }

        public UserEntity(Name name, string occupation, DateTime birthDate, DateTime dateRegister, Email email, bool verified)
        {
            Name = name;
            Occupation = occupation;
            BirthDate = birthDate;
            DateRegister = dateRegister;
            Email = email;
            Verified = verified;
            Validate();
        }

        public void Change_Name(string firstName, string lastName)
        {
            Name = new Name(firstName, lastName);
        }

        public void Change_Occupation(string occupation)
        {
            Occupation = occupation;
            Validate();
        }

        public void Change_BirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
            Validate();
        }

        public void Change_DateRegistrer(DateTime dateRegistrer)
        {
            DateRegister = dateRegistrer;
            Validate();
        }

        public void Change_Verified(bool verified)
        {
            Verified = verified;
            Validate();
        }
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}