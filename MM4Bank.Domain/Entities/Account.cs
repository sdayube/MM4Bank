using MM4Bank.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MM4Bank.Domain.Entities
{
    public sealed class Account : Entity
    {
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; } = 0;
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }
        public List<Transaction> Deposits { get; private set; }
        public List<Transaction> Withdraws { get; private set; }

        private Account(){}

        public Account(int accountNumber)
        {
            ValidateDomain(accountNumber);
        }

        private void ValidateDomain(int accountNumber)
        {
            DomainExceptionValidation.When(accountNumber < 1, "Invalid account number!");

            AccountNumber = accountNumber;
        }

        private void ValidateTransfer(decimal value)
        {
            DomainExceptionValidation.When(value <= 0, $"Invalid transfer value: {value}");
        }

        private void ValidateBalance(decimal value)
        {
            DomainExceptionValidation.When(Balance - value < 0,"Balance not enough!");
        }

        public void Withdraw(decimal value)
        {
            ValidateTransfer(value);
            ValidateBalance(value)
            Balance -= value;
            Withdraws.Add(new Transaction(value, this, null, TransactionType.WITHDRAW));
        }
        public void Deposit(decimal value)
        {
            ValidateTransfer(value);
            Balance += value;
            Deposits.Add(new Transaction(value, null, this, TransactionType.DEPOSIT));
        }

        public void SendTransfer(decimal value, Account targetAccount)
        {
            ValidateTransfer(value);
            ValidateBalance(value)
            Balance -= value;
            Transaction transaction = new Transaction(value, this, targetAccount, TransactionType.TRANSFER);
            Withdraws.Add(transaction);
            targetAccount.ReceiveTransfer(value, this)
        }

        public void ReceiveTransfer(decimal value, Account sourceAccount, Transaction transaction)
        {
            Balance += value;
            Deposits.Add(transaction);
        }
    }
}
