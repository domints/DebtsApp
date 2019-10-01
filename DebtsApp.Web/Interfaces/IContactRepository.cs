using System.Collections.Generic;
using System.Threading.Tasks;
using DebtsApp.Web.APIModels;

namespace DebtsApp.Web.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll(long userId);
        Task Add(long userId, Contact contact);
    }
}