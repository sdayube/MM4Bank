using System;
using MM4Bank.Domain.Validation;
namespace MM4Bank.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        public double Valor { get; set; }
        public DateTime DataTransferencia { get; set; } = DateTime.Now;
        public Account ContaOrigem { get; set; }
        public Account ContaDestino { get; set; }

        public Transaction(double valor, Account contaOrigem, Account contaDestino)
        {
            ValidateDomain(valor, contaOrigem, contaDestino);
        }

        private void ValidateDomain(double valor, Account contaOrigem, Account contaDestino)
        {
            DomainExceptionValidation.When(double.IsNaN(valor), "Invalid value.");
            DomainExceptionValidation.When(valor <= 0, "Invalid value, value must be greater than 0");

            Valor = valor;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
        }
    }
}
