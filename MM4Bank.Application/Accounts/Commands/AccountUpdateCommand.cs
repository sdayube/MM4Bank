using MM4Bank.Application.Accounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Accounts.Commands
{
    public class AccountUpdateCommand : AccountCommand
    {
        public Guid Id { get; set; }
    }
}
