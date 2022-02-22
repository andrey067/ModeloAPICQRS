using Api.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(long id);
        Task<T> SelectAsync(long id);
        Task<IEnumerable<T>> SelectAsyncAll();
        Task<bool> ExistAsync(long id);
    }
}
