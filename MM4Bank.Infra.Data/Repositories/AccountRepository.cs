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
        readonly ApplicationDbContext _accountContext;

        public AccountRepository(ApplicationDbContext context)
        {
            _accountContext = context;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountContext.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(Guid? id)
        {
            return await _accountContext.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _accountContext.Add(account);
            await _accountContext.SaveChangesAsync();

            var createdAccount = await GetByIdAsync(account.Id);
            return createdAccount;
        }

        public async Task<Transaction> WithdrawAsync(Guid? id, decimal value)
        {
            var account = await GetByIdAsync(id);
            var transaction = account.Withdraw(value);

            _accountContext.Add(transaction);
            _accountContext.Update(account);

            await _accountContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> DepositAsync(Guid? id, decimal value)
        {
            var account = await GetByIdAsync(id);
            var transaction = account.Deposit(value);

            _accountContext.Add(transaction);
            _accountContext.Update(account);

            await _accountContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> SendTransferAsync(Guid? sourceId, Guid? targetId, decimal value)
        {
            var sourceAccount = await GetByIdAsync(sourceId);
            var targetAccount = await GetByIdAsync(targetId);
            var transaction = sourceAccount.SendTransfer(value, targetAccount);

            _accountContext.Add(transaction);
            _accountContext.Update(sourceAccount);
            _accountContext.Update(targetAccount);

            await _accountContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<Account> RemoveAsync(Account account)
        {
            _accountContext.Remove(account);
            await _accountContext.SaveChangesAsync();
            return account;
        }
    }
}
