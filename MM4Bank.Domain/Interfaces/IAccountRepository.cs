using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetById(Guid? id);
        Task<Account> Create(Account account);
        Task<Account> Update(Account account);
        Task<Account> Remove(Account account);

    }
}
