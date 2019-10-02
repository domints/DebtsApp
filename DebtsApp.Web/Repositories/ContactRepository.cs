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

        public async Task<bool> Delete(long userId, long contactId)
        {
            var entity = await cx.Contacts.FirstOrDefaultAsync(c => c.Id == contactId && c.OwnerUserId == userId);
            if(entity == null)
                return false;

            cx.Contacts.Remove(entity);
            await cx.SaveChangesAsync();

            return true;
        }

        public Task<List<Contact>> GetAll(long userId)
        {
            return cx.Contacts.Where(c => c.OwnerUserId == userId)
                .Select(c => new Contact { Id = c.Id, Name = c.Name, IsChitUser = c.UserId.HasValue})
                .ToListAsync();         
        }

        public async Task<bool> Update(long userId, long contactId, Contact contact)
        {
            var entity = await cx.Contacts.FirstOrDefaultAsync(c => c.Id == contactId && c.OwnerUserId == userId);
            if(entity == null)
                return false;

            entity.Name = contact.Name;
            await cx.SaveChangesAsync();
            return true;
        }
    }
}