using MM4Bank.Domain.Validation;
using MM4Bank.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Entities
{
public sealed class Client : Entity
    {
        public Name Name { get; private set; }
        public CPF CPF { get; private set; }
        public Account Account { get; private set; }
        private int AccountId { get; set; }
        public Address Address { get; set; }
        public Password Password { get; set; }


        public Client(string name, string cpf, Account account, string address, string password)
        {
            ValidateDomain(name, cpf, account, address, password);
        }

        public Client(int id, string name, string cpf, Account account, string address, string password)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name, cpf, account, address, password);
        }

        public void Update(string name, string cpf, Account account, string address, string password)
        {
            ValidateDomain(name, cpf, account, address, password);
            AccountId = account.Id;
        }

        private void ValidateDomain(string name, string cpf, Account account, string address, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name");
            DomainExceptionValidation.When(cpf.Length != 11 , "Please enter a valid cpf");
            DomainExceptionValidation.When(account is null, "Invalid account");
            DomainExceptionValidation.When(string.IsNullOrEmpty(address), "Invalid address");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Invalid password");
            DomainExceptionValidation.When(password.Length < 8, "Passowrd must be at least 8 characters long");

            Name = new Name(name);
            CPF = new CPF(cpf);
            Account = account;
            Address = new Address(address);
            Password = new Password(password);
        }
    }
}
