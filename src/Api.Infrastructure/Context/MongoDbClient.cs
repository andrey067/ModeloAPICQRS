using Api.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Context
{
    public class MongoDbClient<T> : IMongoDbClient<T> where T : BaseEntity
    {
        private readonly IMongoDatabase _mongoDatabase;

        public IMongoCollection<T> Collection => _mongoDatabase.GetCollection<T>(GetCollectionName(typeof(T)));

        public MongoDbClient(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("ConnectionStringMongo"));
            _mongoDatabase = client.GetDatabase("cesta2irmaoDb");
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public void DeleteOne(string id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Get(string Id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertOne(T obj) => await Collection.InsertOneAsync(obj);


        public void ReplaceOne(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
