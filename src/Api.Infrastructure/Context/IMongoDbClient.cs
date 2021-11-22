using Api.Domain.Entities;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.Context
{
    public interface IMongoDbClient<T>
    {
        IMongoCollection<T> Collection { get; }
        IQueryable<T> GetAll();
        IQueryable<T> Get(string Id);

        Task InsertOne(T obj);

        void ReplaceOne(T obj);

        void DeleteOne(string id);
    }
}
