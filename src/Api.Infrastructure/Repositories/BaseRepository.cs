using Api.Domain.Entities;
using Api.Infrastructure.Context;
using Api.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
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
            return obj;
        }

        public async Task<T> Get(string id) => await DbSet.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task<List<T>> Get() => await DbSet.AsQueryable().ToListAsync();

        public async Task Remove(string id) => await DbSet.DeleteOneAsync(x => x.Id.Equals(ObjectId.Parse(id)));

        public async Task<T> Update(T obj)
        {
            Expression<Func<T, bool>> filter = x => x.Id.Equals(ObjectId.Parse(obj.Id));
            return await DbSet.FindOneAndReplaceAsync(filter, obj);
        }
    }
}
