using MM4Bank.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAccountsAsync();
        Task<AccountDTO> GetByIdAsync(Guid? id);
        Task<TransactionDTO> WithdrawAsync(Guid? id, decimal value);
        Task<TransactionDTO> DepositAsync(Guid? id, decimal value);
        Task<TransactionDTO> SendTransferAsync(Guid? sourceId, Guid? destinationId, decimal value);
        Task RemoveAsync(Guid? id);
    }
}
