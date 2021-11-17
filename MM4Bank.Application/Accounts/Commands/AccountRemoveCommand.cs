using MediatR;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Accounts.Commands
{
    public class AccountRemoveCommand : IRequest<Account>
    {
        public Guid Id { get; set; }

        public AccountRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
