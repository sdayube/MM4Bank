using MM4Bank.Domain.Enum;
using MM4Bank.Domain.Validation;
using System;
using System.Collections.Generic;

namespace MM4Bank.Domain.Entities
{
    public sealed class Account : Entity
    {
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; } = 0m;
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }
        public List<Transaction> Deposits { get; private set; } = new List<Transaction>();
        public List<Transaction> Withdrawals { get; private set; } = new List<Transaction>();

        public Account() { }

        private static void ValidateTransaction(decimal value)
        {
            DomainExceptionValidation.When(value <= 0, $"Invalid transaction value: {value}");
        }

        private void ValidateBalance(decimal value)
        {
            DomainExceptionValidation.When(Balance - value < 0, "Balance not enough!");
        }

        private void ValidateTransfer(decimal value, Account targetAccount)
        {
            ValidateTransaction(value);
            ValidateBalance(value);
            DomainExceptionValidation.When(targetAccount == null, "targetAccount is null!");
        }

        public void Withdraw(decimal value)
        {
            ValidateTransaction(value);
            ValidateBalance(value);
            Withdrawals.Add(new Transaction(value, this, null, TransactionType.WITHDRAWAL));
            Balance -= value;
            this.UpdateEntity();
        }
        public void Deposit(decimal value)
        {
            ValidateTransaction(value);
            Deposits.Add(new Transaction(value, null, this, TransactionType.DEPOSIT));
            Balance += value;
            this.UpdateEntity();
        }

        public void SendTransfer(decimal value, Account targetAccount)
        {
            ValidateTransfer(value, targetAccount);
            Transaction transaction = new(value, this, targetAccount, TransactionType.TRANSFER);
            Balance -= value;
            Withdrawals.Add(transaction);
            targetAccount.ReceiveTransfer(transaction);
            this.UpdateEntity();
            targetAccount.UpdateEntity();
        }

        public void ReceiveTransfer(Transaction transaction)
        {
            Balance += transaction.Value;
            Deposits.Add(transaction);
        }
    }
}
