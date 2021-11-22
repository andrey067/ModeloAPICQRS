using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IBaseEntityForQueryRepository<T> where T : BaseEntity
    {
        Task Create(T obj);
        void Update(T obj);
        void Delete(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> Get();
    }
}
