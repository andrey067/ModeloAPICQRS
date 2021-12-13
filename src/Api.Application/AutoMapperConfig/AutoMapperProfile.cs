using Api.Application.ViewModels;
using Api.Domain.Entities;
using Api.Services.Commands;
using Api.Services.Dtos;
using AutoMapper;

namespace Api.Application.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserViewModel, CreateUserCommand>().ReverseMap();
            CreateMap<UpdateUserViewModel, UpdateUserCommand>().ReverseMap();


            CreateMap<User, UserDto>().ConvertUsing<UserDtoFromUserDomainConverter>();
            //CreateMap<UserDto, CreateUserCommand>().ConvertUsing<CreateUserCommandFromUserDtoConverter>();
            //CreateMap<UserDto, UpdateUserCommand>().ConvertUsing<UpdateUserCommandFromUserDtoConverter>();
        }
    }
}
