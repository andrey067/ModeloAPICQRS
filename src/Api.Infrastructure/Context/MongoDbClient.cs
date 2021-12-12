using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Api.Infrastructure.Context
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbClient(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("ConnectionStringMongo"));
            _mongoDatabase = client.GetDatabase("cesta2irmaoDb");
        }

        public IMongoCollection<T> GetCollection<T>(string name) => _mongoDatabase.GetCollection<T>(name);
    }
}
