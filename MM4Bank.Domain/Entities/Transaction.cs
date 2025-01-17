﻿using System;
using MM4Bank.Domain.Enum;
using MM4Bank.Domain.Validation;

namespace MM4Bank.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        public decimal Value { get; private set; }
        public Guid? SourceAccountId { get; private set; }
        public Account SourceAccount { get; private set; }
        public Guid? TargetAccountId { get; private set; }
        public Account TargetAccount { get; private set; }
        public TransactionType Type { get; private set; }

        private Transaction() { }

        public Transaction(decimal value, Account sourceAccount, Account targetAccount, TransactionType type)
        {
            ValidateDomain(value, sourceAccount);
            Value = value;
            SourceAccountId = sourceAccount?.Id;
            SourceAccount = sourceAccount;
            TargetAccountId = targetAccount?.Id;
            TargetAccount = targetAccount;
            Type = type;
        }

        private void ValidateDomain(decimal value, Account sourceAccount)
        {
            if (sourceAccount != null)
            {
                DomainExceptionValidation.When(value > sourceAccount.Balance, "Not enough balance on source account.");
            }
            DomainExceptionValidation.When(value <= 0, "Invalid value, value must be greater than 0");
        }
    }
}
