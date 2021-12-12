using Api.Domain.Entities;
using Api.Infrastructure.Context;
using Api.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public Task<T> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T obj)
        {
            throw new NotImplementedException();
        }

        //public virtual async Task Create(T obj)
        //{
        //    await DbSet.InsertOneAsync(obj);
        //}

        //public virtual async Task<T> Get(string id)
        //{
        //    return await DbSet.Find(T => T.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task<List<T>> GetAll()
        //{
        //    return await DbSet.AsQueryable().ToListAsync();
        //}

        //public async Task Remove(string id)
        //{
        //    Expression<Func<T, bool>> filter = x => x.Id.Equals(ObjectId.Parse(id));
        //    DeleteResult deleteResult = await DbSet.DeleteOneAsync(filter);
        //}

        //public async Task Update(T obj)
        //{
        //    Expression<Func<T, bool>> filter = x => x.Id.Equals(ObjectId.Parse(obj.Id));
        //    var result = await DbSet.Find(filter).FirstOrDefaultAsync();
        //    if (result != null)
        //        await DbSet.FindOneAndReplaceAsync(filter, obj);
        //}
    }
}
