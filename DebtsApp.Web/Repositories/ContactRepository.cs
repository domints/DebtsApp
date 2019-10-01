using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtsApp.Web.APIModels;
using DebtsApp.Web.Database;
using DebtsApp.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebtsApp.Web.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DebtContext cx;

        public ContactRepository(DebtContext cx)
        {
            this.cx = cx;
        }

        public Task Add(long userId, Contact contact)
        {
            var con = new Database.Models.Contact 
            {
                Name = contact.Name,
                OwnerUserId = userId
            };

            cx.Contacts.Add(con);
            return cx.SaveChangesAsync();
        }

        public Task<List<Contact>> GetAll(long userId)
        {
            return cx.Contacts.Where(c => c.OwnerUserId == userId)
                .Select(c => new Contact { Id = c.Id, Name = c.Name, IsChitUser = c.UserId.HasValue})
                .ToListAsync();         
        }
    }
}