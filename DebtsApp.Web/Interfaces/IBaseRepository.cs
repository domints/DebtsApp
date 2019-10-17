using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtsApp.Web.Interfaces
{
    public interface IBaseRepository<T>
        where T : IIdEntity
    {
        Task<List<T>> GetAll(long userId);
        Task<T> Get(long userId, long entityId);
        Task Add(long userId, T entity);
        Task<bool> Update(long userId, long entityId, T entity);
        Task<bool> Delete(long userId, long entityId);
    }
}