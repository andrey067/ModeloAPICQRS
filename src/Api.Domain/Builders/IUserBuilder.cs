using System;
using Api.Domain.Entities;
using Api.Domain.Entities.ValueObject;
using MongoDB.Bson;

namespace Api.Domain.Builders
{
    public interface IUserBuilder
    {
        User Builder();
        User CreateUserBuilder();
        IUserBuilder WithId(ObjectId id);
        IUserBuilder WithName(Name name);
        IUserBuilder WithOccupation(string ocupation);        
        IUserBuilder WithBirthDate(DateTime birthDate);
        IUserBuilder WithDateRegister();
        IUserBuilder WithEmail(Email email);        
        IUserBuilder WithVerified(bool verified);
    }
}