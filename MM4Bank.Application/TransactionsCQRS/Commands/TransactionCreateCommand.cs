using MediatR;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Transactions.Commands
{
    public class TransactionCreateCommand : IRequest<Transaction>
    {
        public decimal Value { get; set; }
        public Guid? SourceAccountId { get; set; }
        public Account SourceAccount { get; set; }
        public Guid? TargetAccountId { get; set; }
        public Account TargetAccount { get; set; }
        public TransactionType Type { get; set; }
    }
}
