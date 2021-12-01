using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task<T> Create(T obj)
        {
            await DbSet.InsertOneAsync(obj);
            return await Get(obj._id);
        }

        public virtual async Task<T> Get(string id)
        {
            var _id = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await DbSet.Find(filter).SingleAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.AsQueryable().ToListAsync();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
