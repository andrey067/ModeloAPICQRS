using Api.CrossCutting.Dtos;
using MediatR;

namespace Api.Domain.Commands
{
    public class RemoveUserCommand : IRequest<CommandReturnDto>
    {
        public string Id { get; private set; }

        public RemoveUserCommand(string id) => Id = id;
    }
}
