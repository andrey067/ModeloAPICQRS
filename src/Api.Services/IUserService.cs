using Api.CrossCutting.Dtos;
using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService
    {
        Task<CommandReturnDto> Create(UserDto produtoDTO);
        Task<CommandReturnDto> Update(UserDto produtoDTO);
        Task Remove(long id);
        Task<CommandReturnDto> Get(string id);
        Task<List<User>> GetAll();
    }
}
