using System.Collections.Generic;
using System.Threading.Tasks;
using DebtsApp.Web.APIModels;

namespace DebtsApp.Web.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll(long userId);
        Task Add(long userId, Contact contact);
        Task<bool> Update(long userId, long contactId, Contact contact);
        Task<bool> Delete(long userId, long contactId);
    }
}