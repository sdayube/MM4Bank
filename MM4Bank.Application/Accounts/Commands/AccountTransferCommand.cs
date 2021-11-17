using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Accounts.Commands
{
    class AccountTransferCommand : AbstractAccountTransactionCommand
    {
        public Guid TargetId { get; set; }
        public AccountTransferCommand(Guid sourceId, Guid targetId, decimal value) : base(sourceId, value)
        {
            TargetId = targetId;
        }
    }
}
