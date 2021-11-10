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
        //listar propriedades de Account
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }

        //aqui pode ser mudado de name para AccountNumber
        public Account(){}
        public Account(string name)
        {
            ValidateDomain(name);
        }

//  só pra testar
        public Account(Guid id, string name)
        {
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        //podem ser criados n casos de validação aqui
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            Name = name;
        }

        private void ValidateTransfer(decimal value)
        {
            DomainExceptionValidation.When(value <= 0, $"Invalid transfer value: {value}");
        }

        public void Withdraw(decimal value)
        {
            ValidateTransfer(value);
            DomainExceptionValidation.When(Balance - value < 0,"Balance not enough!");
            Balance -= value;
        }
        public void Deposit(decimal value)
        {
            ValidateTransfer(value);
            Balance += value;
        }
        public void Transfer(decimal value, Account destiny_acc, TransactionType type)
        {
            Withdraw(value);
            Transactions.Add(new Transaction(value, this, destiny_acc, type));
        }
    }
}
