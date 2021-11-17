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
        Task<Transaction> WithdrawAsync(Guid? id, decimal value);
        Task<Transaction> DepositAsync(Guid? id, decimal value);
        Task<Transaction> SendTransferAsync(Guid? sourceId, Guid? destinationId, decimal value);
        Task<Account> RemoveAsync(Account account);

    }
}
