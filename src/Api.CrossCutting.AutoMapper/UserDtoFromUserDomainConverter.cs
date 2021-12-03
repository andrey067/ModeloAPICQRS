using Api.CrossCutting.Dtos;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.AutoMapper
{
    class UserDtoFromUserDomainConverter : ITypeConverter<User, UserDto>
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
            Verified =source.Verified
        };
    }
}
