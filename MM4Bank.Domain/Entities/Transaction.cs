using System;
using MM4Bank.Domain.Validation;
namespace MM4Bank.Domain.Entities
{
  public sealed class Transaction : Entity
    {
        public decimal Value { get; set; }
        public Account SourceAccount { get; set; }
        public Account TargetAccount { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(decimal value, Account sourceAccount, Account targetAccount, TransactionType type)
        {
            ValidateDomain(value, sourceAccount);
            Value = value;
            SourceAccount = sourceAccount;
            TargetAccount = targetAccount;
            Type = type;
        }

        private void ValidateDomain(decimal value, Account sourceAccount)
        {
            DomainExceptionValidation.When(value > sourceAccount.Balance, "Not enough balance on source account.");
            DomainExceptionValidation.When(value <= 0, "Invalid value, value must be greater than 0");
        }
    }
}
