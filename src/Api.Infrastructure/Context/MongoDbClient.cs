using Api.Domain.Context;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Context
{
    public class MongoDbClient<T> : IMongoDbClient<T> where T: BaseRepository
    {        
        public IMongoCollection<T> Collection;

        public MongoDbClient(IMongoDbConfig settings)
        {           
            var client = new MongoClient(settings.Connection_String).GetDatabase(settings.DataBase_Name);
            var database = client.GetCollection<T>(GetCollectionName(typeof(T));
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));

        }

        private static string GetCollectionName(Type documentType)
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
