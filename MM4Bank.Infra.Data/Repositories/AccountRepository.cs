using Microsoft.EntityFrameworkCore;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using MM4Bank.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        ApplicationDbContext _accountContext;
        public AccountRepository(ApplicationDbContext context)
        {
            _accountContext = context;
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _accountContext.Add(account);
            await _accountContext.SaveChangesAsync();
            return account;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountContext.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(Guid? id)
        {
            return await _accountContext.Accounts.FindAsync(id);
        }

        public async Task<Account> RemoveAsync(Account account)
        {
            _accountContext.Remove(account);
            await _accountContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            _accountContext.Update(account);
            await _accountContext.SaveChangesAsync();
            return account;
        }
    }
}
