using MM4Bank.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDTO>> GetTransactionsAsync();
        Task<TransactionDTO> GetByIdAsync(Guid? id);
        Task AddAsync(TransactionDTO transactionDTO);
        Task RemoveAsync(Guid? id);
    }
}
