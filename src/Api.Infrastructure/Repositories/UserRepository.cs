using Api.Domain.Entities;
using Api.Infrastructure.Context;
using Api.Infrastructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<List<User>> SearchByEmail(string email)
        {
            Expression<Func<User, bool>> filter = x => x.Email.Address.Equals(email);
            return await DbSet.Find(filter).ToListAsync<User>();
        }

        public async Task<List<User>> SearchByName(string name)
        {
            Expression<Func<User, bool>> filter = x => x.Name.FirstName.Contains(name) || x.Name.LastName.Contains(name);
            return await DbSet.Find(filter).ToListAsync<User>();
        }
    }
}
