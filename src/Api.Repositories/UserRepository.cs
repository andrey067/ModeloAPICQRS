using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infrastructure.Context;

namespace Api.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDbClient context) : base(context)
        {
        }
    }
}
