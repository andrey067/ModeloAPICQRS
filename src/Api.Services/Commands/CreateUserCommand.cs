using Api.Domain.Entities.ValeuObjects;
using Api.Domain.Entities.ValueObject;
using Api.Services.Dtos;
using MediatR;
using System;

namespace Api.Services.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public Name Name { get; private set; }
        public string Occupation { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime DateRegister { get; private set; }
        public Email Email { get; private set; }
        public bool Verified { get; private set; }

        public CreateUserCommand(string firstName, string lastName, string occupation, DateTime birthDate, DateTime dateRegister, string emailaddress, bool verified)
        {
            Name = new(firstName, lastName);
            Occupation = occupation;
            BirthDate = birthDate;
            DateRegister = dateRegister;
            Email = new(emailaddress);
            Verified = verified;
        }
    }
}
