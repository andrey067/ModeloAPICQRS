using Api.CrossCutting.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto userDTO);
        Task<UserDto> Update(UserDto userDTO);
        Task Remove(long id);
        Task<UserDto> Get(long id);
        Task<List<UserDto>> Get();
        Task<List<UserDto>> SearchByName(string name);
        Task<List<UserDto>> SearchByEmail(string email);
        Task<UserDto> GetByEmail(string email);
    }
}
