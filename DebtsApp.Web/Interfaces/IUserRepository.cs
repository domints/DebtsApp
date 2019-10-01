using System.Threading.Tasks;
using DebtsApp.Web.Database.Models;

namespace DebtsApp.Web.Interfaces
{
    public interface IUserRepository
    {
         Task<User> VerifyPassword(string login, string password);
         Task<User> AddUser(string login, string password, string name);
    }
}