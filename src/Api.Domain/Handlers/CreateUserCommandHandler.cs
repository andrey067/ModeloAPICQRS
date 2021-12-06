using Api.CrossCutting.Dtos;
using Api.Domain.Builders;
using Api.Domain.Commands;
using Api.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Domain.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CommandReturnDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CommandReturnDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserBuilder()
                .WithName(request.Name)
                .WithOccupation(request.Occupation)
                .WithBirthDate(request.BirthDate)
                .WithDateRegister()
                .WithEmail(request.Email)
                .WithVerified(true)
                .CreateUserBuilder();

            if (!user.Validate())
                return await Task.FromResult(new CommandReturnDto(false, "Erros foram encontrados", user));

            try
            {
                await _userRepository.Create(user);
                return await Task.FromResult(new CommandReturnDto(true, "Cadastrado com sucesso", _mapper.Map<UserDto>(user)));

            }
            catch (Exception e)
            {
                var retornoComErro = new CommandReturnDto(false, "Erro no cadastro", e.Message);
                return await Task.FromResult(retornoComErro);
            }
        }
    }
}