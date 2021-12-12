using AutoMapper;
using Api.Services.Dtos;
using Api.Domain.Entities;

namespace Api.Application.AutoMapperConfig
{
    public class UserDtoFromUserDomainConverter : ITypeConverter<User, UserDto>
    {
        public UserDto Convert(User source, UserDto destination, ResolutionContext context)
        => new UserDto
        {
            FirstName = source.Name.FirstName,
            LastName = source.Name.LastName,
            Occupation = source.Occupation,
            BirthDate = source.BirthDate,
            DateRegister = source.DateRegister,
            EmailAddress = source.Email.Address,
            Verified = source.Verified
        };
    }
}
