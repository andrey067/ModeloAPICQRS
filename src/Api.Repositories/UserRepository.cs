using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infrastructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMongoDbClient _mongoDbClient;
        private readonly IMongoCollection<User> DbSet;
        public UserRepository(IMongoDbClient context) : base(context)
        {
            _mongoDbClient = context;
            DbSet = _mongoDbClient.GetCollection<User>(typeof(User).Name);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await DbSet.Find(T => T.Email.Address == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> SearchByEmail(string email) => await DbSet.FindAsync(x => x.Email.Address.Equals(email)).Result.ToListAsync();

        public async Task<List<User>> SearchByName(string name) => await DbSet.FindAsync(x => x.Name.FirstName.Equals(name) || x.Name.LastName.Equals(name)).Result.ToListAsync();
    }
}
