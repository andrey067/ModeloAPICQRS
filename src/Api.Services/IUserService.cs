using Api.CrossCutting.Dtos;
using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService
    {
        Task<CommandReturnDto> Create(UserDto userDto);
        Task<CommandReturnDto> Update(UserDto userDto);
        Task<CommandReturnDto> Remove(string id);
        Task<CommandReturnDto> Get(string id);
        Task<List<User>> GetAll();
    }
}
