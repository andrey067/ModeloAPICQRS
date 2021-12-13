using Api.Core.Exceptions;
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

        public User(string id, Name name, string occupation, DateTime birthDate, DateTime dateRegister, Email email, bool verified)
        {
            setId(id);
            setNome(name);
            setOccupation(occupation);
            setBirthDate(birthDate);
            setDateRegister(dateRegister);
            setEmail(email.Address);
            setVerified(verified);
            _errors = new List<string>();
            Validate();
        }

        public User(Name name, string occupation, DateTime birthDate, DateTime dateRegister, Email email, bool verified)
        {
            SetId();
            setNome(name);
            setOccupation(occupation);
            setBirthDate(birthDate);
            setDateRegister(dateRegister);
            setEmail(email.Address);
            setVerified(verified);
            _errors = new List<string>();
            Validate();
        }

        public void setNome(Name name) => Name = new Name(name.FirstName, name.LastName);
        public void setOccupation(string ocupation) => Occupation = ocupation;
        public void setBirthDate(DateTime birthDate) => BirthDate = birthDate;
        public void setDateRegister(DateTime dateRegister) => DateRegister = dateRegister;
        public void setEmail(string email) => Email = new Email(email);
        public void setVerified(bool verified) => Verified = verified;

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }
            return true;
        }
    }
}