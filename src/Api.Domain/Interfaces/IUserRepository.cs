using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
