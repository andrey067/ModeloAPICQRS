using Api.CrossCutting.Dtos;
using Api.Domain.Builders;
using Api.Domain.Commands;
using Api.Domain.Entities;
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
        private readonly IBaseEntityForQueryRepository<User> _baseEntityForQueryRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IBaseEntityForQueryRepository<User> baseEntityForQueryRepository, IMapper mapper)
        {
            _baseEntityForQueryRepository = baseEntityForQueryRepository;
            _mapper = mapper;
        }


        public Task<CommandReturnDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
                return Task.FromResult(new CommandReturnDto(false, "Erros foram encontrados", user));

            try
            {
                _baseEntityForQueryRepository.Create(user);

                return Task.FromResult(new CommandReturnDto(true, "Cadastrado com sucesso", user));

            }
            catch (Exception e )
            {
                var retornoComErro = new CommandReturnDto(false, "Erro no cadastro", e.Message);
                return Task.FromResult(retornoComErro);
            }
        }
    }
}