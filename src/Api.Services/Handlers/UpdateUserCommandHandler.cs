using Api.Core.Exceptions;
using Api.Domain.Entities.ValeuObjects;
using Api.Domain.Entities.ValueObject;
using Api.Infrastructure.Interfaces;
using Api.Services.Commands;
using Api.Services.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO - adicionar failfast Validation
            var user = await _userRepository.Get(request.Id);
            if (user == null)
                throw new DomainException("Não existe nenhum usuário com o id informado!");

            user.setNome(request.Name);
            user.setOccupation(request.Occupation);
            user.setBirthDate(request.BirthDate);
            user.setEmail(request.Email.Address);
            user.setVerified(request.Verified);
            user.Validate();

            return await Task.FromResult(_mapper.Map<UserDto>(_userRepository.Update(user)));
        }
    }
}