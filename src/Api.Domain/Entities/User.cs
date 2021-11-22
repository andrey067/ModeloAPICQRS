using System;
using Api.Domain.Entities.ValueObject;
using Api.Domain.Validators;
using Api.Shared.Exceptions;

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
            setNome(name);
            setOccupation(occupation);
            setBirthDate(birthDate);            
            setEmail(email);
            setVerified(verified);
        }

        public User(Name name, string occupation, DateTime birthDate,DateTime dateRegister, Email email, bool verified)
        {
            setId();
            setNome(name);
            setOccupation(occupation);
            setBirthDate(birthDate);
            seDateRegister(dateRegister);
            setEmail(email);
            setVerified(verified);
        }

        public void setNome(Name name) => Name = name;
        public void setOccupation(string ocupation) => Occupation = ocupation;
        public void setBirthDate(DateTime birthDate) => BirthDate = birthDate;
        public void seDateRegister(DateTime dateRegister) => DateRegister = dateRegister;
        public void setEmail(Email email) => Email = email;
        public void setVerified(bool verified) => Verified = verified;

        public override bool Validate()
        {
            var validator = new UserValidators();
            var validation = validator.Validate(this);

            //Pega os erros na camada de dominio
            if (!validation.IsValid)
            {
                if (!validation.IsValid)
                {
                    foreach (var error in validation.Errors)
                        _errors.Add(error.ErrorMessage);

                    throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
                }
            }
            return true;
        }
    }
}