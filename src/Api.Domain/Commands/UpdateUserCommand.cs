using Api.CrossCutting.Dtos;
using Api.Domain.Entities.ValueObject;
using MediatR;
using System;

namespace Api.Domain.Commands
{
    public class UpdateUserCommand : IRequest<CommandReturnDto>
    {
        public string Id { get; private set; }
        public Name Name { get; private set; }
        public string Occupation { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime DateRegister { get; private set; }
        public Email Email { get; private set; }
        public bool Verified { get; private set; }

        public UpdateUserCommand(string id, Name name, string occupation, DateTime birthDate, DateTime dateRegister, Email email, bool verified)
        {
            Id = id;
            Name = name;
            Occupation = occupation;
            BirthDate = birthDate;
            DateRegister = dateRegister;
            Email = email;
            Verified = verified;
        }

        public UpdateUserCommand(Name name, string occupation, DateTime birthDate, DateTime dateRegister, Email email, bool verified)
        {
            Name = name;
            Occupation = occupation;
            BirthDate = birthDate;
            DateRegister = dateRegister;
            Email = email;
            Verified = verified;
        }
    }
}
