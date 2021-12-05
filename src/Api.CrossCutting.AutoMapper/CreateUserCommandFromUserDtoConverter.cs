using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Entities.ValueObject;
using AutoMapper;

namespace Api.CrossCutting.AutoMapper
{
    public class CreateUserCommandFromUserDtoConverter : ITypeConverter<UserDto, CreateUserCommand>
    {
        public CreateUserCommand Convert(UserDto source, CreateUserCommand destination, ResolutionContext context)
        => new CreateUserCommand
        (
           new Name(source.FirstName, source.LastName),
           source.Occupation,
           source.BirthDate,
           source.DateRegister,
           new Email(source.EmailAddress),
           source.Verified
        );
    }
}