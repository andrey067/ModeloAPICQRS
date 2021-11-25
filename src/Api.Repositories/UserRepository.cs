using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Repositories;

namespace Api.Infrastructure.Context
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoContext context) : base(context)
        {
        }
    }
}
