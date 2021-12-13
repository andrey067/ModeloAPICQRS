using Api.Core.Exceptions;
using Api.Domain.Builders;
using Api.Infrastructure.Interfaces;
using Api.Services.Commands;
using Api.Services.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO - adicionar failfast Validation
            var userExist = await _userRepository.GetByEmail(request.Email.Address);
            if (userExist != null)
                throw new DomainException("Já existe um usuário cadastrado com o email informado.");

            var user = new UserBuilder()
                .WithName(request.Name)
                .WithOccupation(request.Occupation)
                .WithBirthDate(request.BirthDate)
                .WithDateRegister()
                .WithEmail(request.Email)
                .WithVerified(true)
                .CreateUserBuilder();

            if (!user.Validate())
                throw new DomainException("Alguns campos não são validos");

            return await Task.FromResult(_mapper.Map<UserDto>(_userRepository.Create(user)));
        }
    }
}
