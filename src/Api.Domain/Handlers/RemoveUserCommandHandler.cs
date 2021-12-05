using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Domain.Handlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, CommandReturnDto>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<CommandReturnDto> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _userRepository.Remove(request.Id);

                return Task.FromResult(new CommandReturnDto(true, "Removido com sucessso"));
            }
            catch (Exception e)
            {
                var retornoComErro = new CommandReturnDto(false, "Erro no cadastro", e.Message);
                return Task.FromResult(retornoComErro);
            }
        }
    }
}
