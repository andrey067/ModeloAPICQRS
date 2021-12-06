using Api.CrossCutting.Dtos;
using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService
    {
        void Create(UserDto userDto);
        void Update(UserDto userDto);
        void Remove(string id);
        Task<CommandReturnDto> Get(string id);
        Task<List<User>> GetAll();
    }
}
