using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ConvertUsing<UserDtoFromUserDomainConverter>();
            CreateMap<UserDto, CreateUserCommand>().ConvertUsing<CreateUserCommandFromUserDtoConverter>();
            CreateMap<UserDto, UpdateUserCommand>().ConvertUsing<UpdateUserCommandFromUserDtoConverter>();
        }
    }
}
