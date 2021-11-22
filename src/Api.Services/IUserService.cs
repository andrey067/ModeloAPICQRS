using Api.CrossCutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService
    {
        Task<CommandReturnDto> Create(UserDto produtoDTO);
        Task<CommandReturnDto> Update(UserDto produtoDTO);
        Task Remove(long id);
        Task<CommandReturnDto> Get(long id);
        Task<List<UserDto>> GetAll();
    }
}
