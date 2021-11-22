using System;
using Api.Domain.Entities;
using Api.Domain.Entities.ValueObject;

namespace Api.Domain.Builders
{
    public class UserBuilder : IUserBuilder
    {
        private string _id;
        private Name _name;
        private string _occupation;
        private DateTime _birthDate;
        private DateTime _dateRegister;
        private Email _email;
        private bool _verified;

        public User Builder() => new User(_id, _name, _occupation, _birthDate, _dateRegister, _email, _verified);
        public User CreateUserBuilder() => new User(_name, _occupation, _birthDate, _dateRegister, _email, _verified);
        public IUserBuilder WithBirthDate(DateTime birthDate)
        {
            _birthDate = birthDate;
            return this;
        }

        public IUserBuilder WithEmail(Email email)
        {
            _email = new Email(email.Address);
            return this;
        }

        public IUserBuilder WithName(Name name)
        {
            _name = new Name(name.FirstName, name.LastName);
            return this;
        }

        public IUserBuilder WithOccupation(string occupation)
        {
            _occupation = occupation;
            return this;
        }

        public IUserBuilder WithVerified(bool verified)
        {
            _verified = verified;
            return this;
        }

        public IUserBuilder WithDateRegister()
        {
            _dateRegister = DateTime.Now;
            return this;
        }

        public IUserBuilder WithId(string id)
        {
            _id = id;
            return this;
        }
    }
}