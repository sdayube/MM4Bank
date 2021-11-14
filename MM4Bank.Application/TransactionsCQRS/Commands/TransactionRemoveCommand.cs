using MediatR;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Transactions.Commands
{
    public class TransactionRemoveCommand : IRequest<Transaction>
    {
        public Guid Id { get; set; }

        public TransactionRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
