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
    public class TransactionRepository : ITransactionRepository
    {
        ApplicationDbContext _transactionContext;

        public TransactionRepository(ApplicationDbContext context)
        {
            _transactionContext = context;
        }

        public async Task<Transaction> Create(Transaction transaction)
        {
            _transactionContext.Add(transaction);
            await _transactionContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> GetById(int? id)
        {
            return await _transactionContext.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _transactionContext.Transactions.ToListAsync();
        }

        public async Task<Transaction> Remove(Transaction transaction)
        {
            _transactionContext.Remove(transaction);
            await _transactionContext.SaveChangesAsync();
            return transaction;
        }

    }
}


