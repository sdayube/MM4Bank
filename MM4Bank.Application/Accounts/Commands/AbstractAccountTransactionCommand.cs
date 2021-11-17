using MediatR;
using MM4Bank.Application.Accounts.Commands;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MM4Bank.Application.Accounts.Commands
{
    public abstract class AbstractAccountTransactionCommand : IRequest<Transaction>
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }

        public AbstractAccountTransactionCommand(Guid id, decimal value)
        {
            Id = id;
            Value = value;
        }
    }
}
