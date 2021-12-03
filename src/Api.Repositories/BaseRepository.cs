using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IMongoDbClient _mongoDbClient;
        private readonly IMongoCollection<T> DbSet;

        public BaseRepository(IMongoDbClient mongoDbClient)
        {
            _mongoDbClient = mongoDbClient;
            DbSet = _mongoDbClient.GetCollection<T>(typeof(T).Name);
        }

        public virtual async void Create(T obj)
        {
            await DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<T> Get(string id)
        {
            return await DbSet.Find(T => T.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.AsQueryable().ToListAsync();
        }

        public async Task Remove(string id)
        {
            Expression<Func<T, bool> > filter = x => x.Id.Equals(ObjectId.Parse(id));
            DeleteResult deleteResult = await DbSet.DeleteOneAsync(filter);            
        }

        public Task<T> Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
