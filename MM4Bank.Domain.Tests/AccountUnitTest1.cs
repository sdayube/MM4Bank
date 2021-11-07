using FluentAssertions;
using MM4Bank.Domain.Entities;
using System;
using Xunit;

namespace MM4Bank.Domain.Tests
{
    public class AccountUnitTest1
    {
        //Fact seria semelhante ao Describe do Jest
        [Fact(DisplayName ="Create Account With Valid Parameters")]
        //Padrão de escrita de função de teste -> nomeDoQuêEstáSendoTestado_InfoDoCenárioDoTeste_ResultadoEsperado
        public void CreateAccount_WithValidParameters_ResultObjectValidState()
        {
            //estrutura padrão do pacote Fluent Assertions
            Action action = () => new Account(1, "Account Number");
            action.Should()
                .NotThrow<MM4Bank.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Testing Invalid Id Value")]
        public void CreateAccount_NegativeIdValue_DomainExcepetionInvalidId()
        {            
            Action action = () => new Account(-1, "Account Number");
            action.Should().Throw < MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }

        [Fact(DisplayName = "Testing Short Name Value")]
        public void CreateAccount_ShortNameValue_DomainExcepetionShortName()
        {
            Action action = () => new Account(1, "Ac");
            action.Should().Throw<MM4Bank.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }
    }
}
