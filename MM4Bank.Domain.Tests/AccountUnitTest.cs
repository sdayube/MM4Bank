using FluentAssertions;
using MM4Bank.Domain.Entities;
using System;
using Xunit;

namespace MM4Bank.Domain.Tests
{
    public class AccountUnitTest
    {
        [Fact(DisplayName ="Create Account With Valid Parameters")]
        public void CreateAccount_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Account(1);
            action.Should()
                .NotThrow<MM4Bank.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Account With Invalid Account Number")]
        public void CreateAccount_InvalidAccountNumber_ResultObjectInvalidState()
        {            
            Action action = () => new Account(-1);
            action.Should().Throw < MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid account number!");
        }

        [Fact(DisplayName = "Realize a deposit")]
        public void RealizeDeposit_WithValidParameters_ResultBalanceChange()
        {
            Account account = new(123);

            account.Deposit(1000m);
            Assert.Equal(1000m, account.Balance);
        }

        [Fact(DisplayName = "Realize a deposit with negative value")]
        public void RealizeDeposit_WithNegativeValue_ThrowError()
        {
            Account account = new(123);

            decimal value = -1000m;
            Action action = () => account.Deposit(value);
            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"Invalid transaction value: {value}");
        }

        [Fact(DisplayName = "Realize a withdraw")]
        public void RealizeWithdraw_WithValidParameters_ResultBalanceChange()
        {
            Account account = new(123);

            account.Deposit(2000m);
            Assert.Equal(2000m, account.Balance);
            account.Withdraw(1000m);
            Assert.Equal(1000m, account.Balance);
        }

        [Fact(DisplayName = "Realize a withdraw with negative value")]
        public void RealizeWithdraw_WithNegativeValue_ThrowError()
        {
            Account account = new(123);
            account.Deposit(2000m);

            decimal value = -1000m;
            Action action = () => account.Withdraw(value);
            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage($"Invalid transaction value: {value}");
        }

        [Fact(DisplayName = "Realize a withdraw without balance")]
        public void RealizeWithdraw_WithoutBalance_ThrowError()
        {
            Account account = new(123);

            decimal value = 1000m;
            Action action = () => account.Withdraw(value);
            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Balance not enough!");
        }

        [Fact(DisplayName = "Realize a transfer")]
        public void RealizeTranfer_WithValidParameters_ResultBalanceChange()
        {
            Account account1 = new(123);
            Account account2 = new(321);

            account1.Deposit(2000m);
            account1.SendTransfer(1000m, account2);

            Assert.Equal(1000m, account1.Balance);
            Assert.Equal(1000m, account2.Balance);
        }

        [Fact(DisplayName = "Realize a transfer without balance")]
        public void RealizeTranfer_WithoutBalance_ResultBalanceChange()
        {
            Account account1 = new(123);
            Account account2 = new(321);

            Action action = () => account1.SendTransfer(1000m, account2);

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Balance not enough!");
        }

        [Fact(DisplayName = "Realize a transfer without target account")]
        public void RealizeTranfer_WithoutTargetAccount_ResultBalanceChange()
        {
            Account account1 = new(123);

            account1.Deposit(2000m);
            Action action = () => account1.SendTransfer(1000m, null);

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("targetAccount is null!");
        }
    }
}
