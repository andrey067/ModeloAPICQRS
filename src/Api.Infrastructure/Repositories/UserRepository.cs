using Api.Domain.Entities;
using Api.Infrastructure.Context;
using Api.Infrastructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMongoCollection<User> DbSet;
        public UserRepository(IMongoDbClient context) : base(context)
        {
            DbSet = context.GetCollection<User>(typeof(User).Name);
        }

        public async Task<User> GetByEmail(string email)
        {
            Expression<Func<User, bool>> filter = x => x.Email.Address.Equals(email);
            return await DbSet.Find(filter).FirstOrDefaultAsync();
        }

        public Task<List<User>> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
