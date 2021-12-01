using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Api.Infrastructure.Context
{
    public interface IMongoDbClient
    {       
        IMongoCollection<T> GetCollection<T>(string name);
    }
}