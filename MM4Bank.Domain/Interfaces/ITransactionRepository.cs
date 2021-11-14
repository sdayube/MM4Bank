using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> GetById(Guid? id);
        Task<Transaction> Create(Transaction transaction);
        Task<Transaction> Remove(Transaction transaction);

    }
}
