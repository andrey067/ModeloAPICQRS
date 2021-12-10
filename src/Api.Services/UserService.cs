using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Interfaces;
using Api.Shared.Exceptions;
using AutoMapper;
using MassTransit.Mediator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMediator mediator, IMapper mapper, IUserRepository clienteForQueryRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userRepository = clienteForQueryRepository;
        }

        public async Task<UserDto> Create(UserDto userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.EmailAddress);

            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o email informado.");

            var t = await _mediator.Send(_mapper.Map<CreateUserCommand>(userDTO));
        }

        public Task<UserDto> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserDto>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserDto>> SearchByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserDto>> SearchByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> Update(UserDto userDTO)
        {
            throw new System.NotImplementedException();
        }







        //public async Task Create(UserDto userDto) => await _mediator.Send(_mapper.Map<CreateUserCommand>(userDto));


        //public async Task Delete(string id) => await _mediator.Send(new RemoveUserCommand(id));

        //public async Task<List<User>> GetAll() => await _userRepository.GetAll();

        //public async Task<CommandReturnDto> GetById(string id)
        //{
        //    var result = await _userRepository.Get(id);
        //    if (result != null)
        //        return new CommandReturnDto(true, "Dados encontrados", result);
        //    return new CommandReturnDto(false, "Erros foram encontrados", result);
        //}

        //public async Task Update(UserDto userdto) => await _mediator.Send(_mapper.Map<UpdateUserCommand>(userdto));
    }
}
