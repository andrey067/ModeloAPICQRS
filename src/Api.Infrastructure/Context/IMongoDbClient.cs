using MongoDB.Driver;

namespace Api.Infrastructure.Context
{
    public interface IMongoDbClient
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
