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
        private readonly IBaseEntityForQueryRepository<User> _baseEntityForQueryRepository;

        public UserService(IMediator mediator, IMapper mapper, IBaseEntityForQueryRepository<User> baseEntityForQueryRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _baseEntityForQueryRepository = baseEntityForQueryRepository;
        }

        public async Task<CommandReturnDto> Create(UserDto userdto)
            => await _mediator.Send(_mapper.Map<CreateUserCommand>(userdto));

        public Task<CommandReturnDto> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandReturnDto> Update(UserDto produtoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
