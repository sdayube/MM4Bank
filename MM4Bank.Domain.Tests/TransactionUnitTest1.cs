using FluentAssertions;
using MM4Bank.Domain.Entities;
using System;
using Xunit;

namespace MM4Bank.Domain.Tests
{
    public class TransactionUnitTest1
    {
        [Fact(DisplayName = "Create Transaction With Negative Value")]
        
        public void CreateAccount_WithValidParameters_ResultObjectValidState()
        {            
            Action action = () => new Transaction(-1, new Account("Source Account Number"), new Account("Target Account Number"));
            action.Should().Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid value, value must be greater than 0");
        }
    }
}
