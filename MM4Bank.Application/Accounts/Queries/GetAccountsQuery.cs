using MediatR;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Accounts.Queries
{
    public class GetAccountsQuery : IRequest<IEnumerable<Account>>
    {
    }
}
