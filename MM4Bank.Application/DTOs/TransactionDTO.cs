using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.DTOs
{
    public class TransactionDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Value is required!")]
        public decimal Value { get; private set; }

        public Guid SourceAccountId { get; private set; }

        public Account SourceAccount { get; private set; }

        public Guid TargetAccountId { get; private set; }

        public Account TargetAccount { get; private set; }

        [Required(ErrorMessage = "Transaction type is required!")]
        public TransactionType Type { get; private set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
