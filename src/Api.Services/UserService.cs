using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMediator mediator, IMapper mapper, IUserRepository userRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CommandReturnDto> Create(UserDto userdto) => await _mediator.Send(_mapper.Map<CreateUserCommand>(userdto));

        public async Task<CommandReturnDto> Get(string id)
        {
            var result = await _userRepository.Get(id);
            if (result != null)
                return new CommandReturnDto(true, "Dados encontrados", result);
            return new CommandReturnDto(false, "Erros foram encontrados", result);
        }

        public async Task<List<User>> GetAll() => await _userRepository.GetAll();


        public async Task<CommandReturnDto> Remove(string id) => await _mediator.Send(new RemoveUserCommand(id));

        public async Task<CommandReturnDto> Update(UserDto userdto) => await _mediator.Send(_mapper.Map<UpdateUserCommand>(userdto));
    }
}
