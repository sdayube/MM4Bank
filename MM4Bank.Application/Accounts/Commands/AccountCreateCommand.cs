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
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public List<Transaction> Deposits { get; set; }
        public List<Transaction> Withdrawals { get; set; }
    }
}
