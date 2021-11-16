using MediatR;
using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Transactions.Queries
{
    public class GetTransactionsQuery : IRequest<IEnumerable<Transaction>>
    {
    }
}
