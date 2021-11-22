using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class BaseEntityForQueryRepository<T> : IBaseEntityForQueryRepository<T> where T : BaseEntity
    {
        private readonly IMongoDbClient<T> _mongoDbClient;

        public BaseEntityForQueryRepository(IMongoDbClient<T> mongoDbContext)
        {
            _mongoDbClient = mongoDbContext;
        }

        public async Task Create(T obj)
        {
            await _mongoDbClient.InsertOne(obj);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
