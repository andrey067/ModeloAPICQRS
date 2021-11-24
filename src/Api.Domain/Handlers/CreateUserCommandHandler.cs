using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Domain.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CommandReturnDto>
    {


        public Task<CommandReturnDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();

            //var user = new UserBuilder()
            //    .WithName(request.Name)
            //    .WithOccupation(request.Occupation)
            //    .WithBirthDate(request.BirthDate)
            //    .WithDateRegister()
            //    .WithEmail(request.Email)
            //    .WithVerified(true)
            //    .CreateUserBuilder();

            //if (!user.Validate())
            //    return Task.FromResult(new CommandReturnDto(false, "Erros foram encontrados", user));

            //try
            //{
            //    var response = _baseEntityForQueryRepository.Create(user);

            //    return Task.FromResult(new CommandReturnDto(true, "Cadastrado com sucesso", response));

            //}
            //catch (Exception e)
            //{
            //    var retornoComErro = new CommandReturnDto(false, "Erro no cadastro", e.Message);
            //    return Task.FromResult(retornoComErro);
            //}
        }
    }
}