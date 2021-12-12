using Api.Application.ViewModels;
using Api.Domain.Entities;
using Api.Services.Commands;
using Api.Services.Dtos;
using AutoMapper;

namespace Api.CrossCutting.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserViewModel, CreateUserCommand>().ReverseMap();

            //CreateMap<User, UserDto>().ConvertUsing<UserDtoFromUserDomainConverter>();
        }
    }
}
