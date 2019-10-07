using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtsApp.Web.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(long userId);
        Task Add(long userId, T entity);
        Task<bool> Update(long userId, long entityId, T entity);
        Task<bool> Delete(long userId, long entityId);
    }
}