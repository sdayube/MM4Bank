using MediatR;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Accounts.Commands
{
    public class AccountCreateCommand : IRequest<Account>
    {
    }
}
