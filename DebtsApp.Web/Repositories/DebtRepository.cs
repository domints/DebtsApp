using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtsApp.Web.APIModels;
using DebtsApp.Web.Database;
using DebtsApp.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebtsApp.Web.Repositories 
{
    public class DebtRepository : IDebtRepository
    {
        private readonly DebtContext cx;

        public DebtRepository(DebtContext cx)
        {
            this.cx = cx;
        }

        public Task Add(long userId, Debt debt)
        {
            var d = new Database.Models.Debt {
                CreatorId = userId,
                IsMyDebt = debt.IsMyDebt,
                OtherContactId = debt.OtherId,
                Description = debt.Description,
                Value = debt.Value
            };

            cx.Debts.Add(d);
            return cx.SaveChangesAsync();
        }

        public async Task<bool> Delete(long userId, long debtId)
        {
            var entity = await cx.Debts.FirstOrDefaultAsync(c => c.Id == debtId && c.CreatorId == userId);
            if(entity == null)
                return false;

            cx.Debts.Remove(entity);
            await cx.SaveChangesAsync();

            return true;
        }

        public Task<Debt> Get(long userId, long entityId)
        {
            return cx.Debts.Where(d => d.Id == entityId && d.CreatorId == userId).Select(d => 
            new Debt {
                Id = d.Id,
                IsMyDebt = d.IsMyDebt,
                Value = d.Value,
                Description = d.Description,
                OtherId = d.OtherContactId.Value,
                OtherName = d.OtherContact.Name
            }).FirstOrDefaultAsync();
        }

        public Task<List<Debt>> GetAll(long userId)
        {
            return cx.Debts.Where(d => d.CreatorId == userId).Select(d => 
            new Debt {
                Id = d.Id,
                IsMyDebt = d.IsMyDebt,
                Value = d.Value,
                Description = d.Description,
                OtherId = d.OtherContactId.Value,
                OtherName = d.OtherContact.Name
            }).ToListAsync();
        }

        public async Task<bool> Update(long userId, long debtId, Debt debt)
        {
            var entity = await cx.Debts.FirstOrDefaultAsync(c => c.Id == debtId && c.CreatorId == userId);
            if(entity == null)
                return false;

            entity.Description = debt.Description;
            entity.Value = debt.Value;
            entity.IsMyDebt = debt.IsMyDebt;
            entity.OtherContactId = debt.OtherId;

            await cx.SaveChangesAsync();

            return true;         
        }
    }
}