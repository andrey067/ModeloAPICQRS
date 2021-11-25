using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task Add(T obj);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T obj);
        Task Remove(Guid id);
    }
}