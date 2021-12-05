using Api.CrossCutting.Dtos;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CommandReturnDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<CommandReturnDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _userRepository.Get(request.Id).Result;
            user.setNome(request.Name);
            user.setBirthDate(request.BirthDate);
            user.setEmail(request.Email);
            user.setDateRegister(request.DateRegister);
            user.setOccupation(request.Occupation);
            user.setVerified(request.Verified);

            if (!user.Validate())
                return Task.FromResult(new CommandReturnDto(false, "Erros foram encontrados", user));

            try
            {
                _userRepository.Update(user);
                return Task.FromResult(new CommandReturnDto(true, "Atualizado com sucesso", _mapper.Map<UserDto>(user)));

            }
            catch (Exception e)
            {
                var retornoComErro = new CommandReturnDto(false, "Erro ao atualizar", e.Message);
                return Task.FromResult(retornoComErro);
            }
        }
    }
}
