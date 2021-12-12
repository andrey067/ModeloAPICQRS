using Api.Domain.Entities;
using Api.Domain.Entities.ValeuObjects;
using Api.Domain.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Builders.InterfacesBuilders
{
    public interface IUserBuilder
    {
        User Builder();
        User CreateUserBuilder();
        IUserBuilder WithId(string id);
        IUserBuilder WithName(Name name);
        IUserBuilder WithOccupation(string ocupation);
        IUserBuilder WithBirthDate(DateTime birthDate);
        IUserBuilder WithDateRegister();
        IUserBuilder WithEmail(Email email);
        IUserBuilder WithVerified(bool verified);
    }
}
