using FluentAssertions;
using MM4Bank.Domain.Entities;
using System;
using Xunit;

namespace MM4Bank.Domain.Tests
{
    public class ClientUnitTest
    {
        string name = "Júlio Kauer";
        string cpf = "12345678900";
        Account account = new();
        string address = "Av Integração";
        string password = "senhaSegura";

        [Fact(DisplayName = "Create Client With Valid Parameters")]
        public void CreateAccount_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Client(name, cpf, account, address, password);
            };

            action.Should()
                .NotThrow<MM4Bank.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Client With empty name")]
        public void CreateAccount_WithEmptyName_ResultObjectValidState()
        {
            var name = "";
            Action action = () =>
            {
                new Client(name, cpf, account, address, password);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name");
        }

        [Fact(DisplayName = "Create Client With null name")]
        public void CreateAccount_WithNullName_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Client(null, cpf, account, address, password);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name");
        }

        [Fact(DisplayName = "Create Client With invalid CPF")]
        public void CreateAccount_WithInvalidCPF_ResultObjectValidState()
        {
            var invalidCpf = "123456";
            Action action = () =>
            {
                new Client(name, invalidCpf, account, address, password);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Please enter a valid cpf");
        }

        [Fact(DisplayName = "Create Client With invalid account")]
        public void CreateAccount_WithInvalidAccount_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Client(name, cpf, null, address, password);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid account");
        }

        [Fact(DisplayName = "Create Client With empty address")]
        public void CreateAccount_WithEmptyAddress_ResultObjectValidState()
        {
            var emptyAddress = "";
            Action action = () =>
            {
                new Client(name, cpf, account, emptyAddress, password);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid address");
        }

        [Fact(DisplayName = "Create Client With null address")]
        public void CreateAccount_WithNullAddress_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Client(name, cpf, account, null, password);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid address");
        }

        [Fact(DisplayName = "Create Client With empty password")]
        public void CreateAccount_WithEmptyPassword_ResultObjectValidState()
        {
            var emptyPassword = "";
            Action action = () =>
            {
                new Client(name, cpf, account, address, emptyPassword);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid password");
        }

        [Fact(DisplayName = "Create Client With null password")]
        public void CreateAccount_WithNullPassword_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Client(name, cpf, account, address, null);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid password");
        }

        [Fact(DisplayName = "Create Client With too short password")]
        public void CreateAccount_WithTooShortPassword_ResultObjectValidState()
        {
            var shortPassword = "1234";
            Action action = () =>
            {
                new Client(name, cpf, account, address, shortPassword);
            };

            action.Should()
                .Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Password must be at least 8 characters long");
        }
    }
}

