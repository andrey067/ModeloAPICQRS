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

        public virtual async Task<T> Create(T obj)
        {
            await DbSet.InsertOneAsync(obj);
            return obj;
        }

        public virtual async Task<T> Get(string id) => await DbSet.Find(T => T.Id == id).FirstOrDefaultAsync();

        public async Task<List<T>> Get() => await DbSet.AsQueryable().ToListAsync();

        public virtual async Task Remove(string id)
        {
            Expression<Func<T, bool>> filter = x => x.Id.Equals(ObjectId.Parse(id));
            var result = await DbSet.Find(filter).FirstOrDefaultAsync();
            if (result != null)
                await DbSet.DeleteOneAsync(filter);
        }

        public virtual async Task<T> Update(T obj)
        {
            Expression<Func<T, bool>> filter = x => x.Id.Equals(ObjectId.Parse(obj.Id));
            var result = await DbSet.Find(filter).FirstOrDefaultAsync();
            return await DbSet.FindOneAndReplaceAsync(filter, obj);
        }
    }
}
