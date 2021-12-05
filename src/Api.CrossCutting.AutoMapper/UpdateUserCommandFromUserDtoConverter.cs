using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Entities.ValueObject;
using AutoMapper;
using System;

namespace Api.CrossCutting.AutoMapper
{
    public class UpdateUserCommandFromUserDtoConverter : ITypeConverter<UserDto, UpdateUserCommand>
    {
        public UpdateUserCommand Convert(UserDto source, UpdateUserCommand destination, ResolutionContext context)
        => new UpdateUserCommand
        (
           source.Id,
           new Name(source.FirstName, source.LastName),
           source.Occupation,
           source.BirthDate,
           source.DateRegister,
           new Email(source.EmailAddress),
           source.Verified
        );
    }
}
