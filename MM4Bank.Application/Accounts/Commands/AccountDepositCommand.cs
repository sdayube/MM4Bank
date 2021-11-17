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
    public class AccountDepositCommand : AbstractAccountTransactionCommand
    {
        public AccountDepositCommand(Guid id, decimal value) : base(id, value)
        {
        }
    }
}
