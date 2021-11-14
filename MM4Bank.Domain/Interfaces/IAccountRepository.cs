using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetByIdAsync(Guid? id);

        Task<Account> CreateAsync(Account account);
        Task<Account> UpdateAsync(Account account);
        Task<Account> RemoveAsync(Account account);

    }
}
