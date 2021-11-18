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

        public Transaction Withdraw(decimal value)
        {
            ValidateTransaction(value);
            ValidateBalance(value);
            Transaction transaction = new(value, this, null, TransactionType.WITHDRAWAL);

            Balance -= value;

            this.UpdateEntity();

            return transaction;
        }

        public Transaction Deposit(decimal value)
        {
            ValidateTransaction(value);
            Transaction transaction = new(value, null, this, TransactionType.DEPOSIT);

            Balance += value;

            this.UpdateEntity();

            return transaction;
        }

        public Transaction SendTransfer(decimal value, Account targetAccount)
        {
            ValidateTransfer(value, targetAccount);
            Transaction transaction = new(value, this, targetAccount, TransactionType.TRANSFER);

            Balance -= value;
            targetAccount.ReceiveTransfer(transaction);

            this.UpdateEntity();
            targetAccount.UpdateEntity();

            return transaction;
        }

        public void ReceiveTransfer(Transaction transaction)
        {
            Balance += transaction.Value;
        }

        public void SetClientId(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
