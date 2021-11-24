using Api.CrossCutting.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserService : IUserService
    {
        public async Task<CommandReturnDto> Create(UserDto userdto)
        {
            throw new NotImplementedException();
        }

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
