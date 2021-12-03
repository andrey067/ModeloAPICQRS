using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T obj);
        Task<T> Update(T obj);
        Task Remove(string id);
        Task<T> Get(string id);
        Task<List<T>> GetAll();
    }
}