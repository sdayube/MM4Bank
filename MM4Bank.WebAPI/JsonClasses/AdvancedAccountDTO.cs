using MM4Bank.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.JsonClasses
{
    public class AdvancedAccountDTO
    {
        public Guid Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public Guid ClientId { get; set; }
        public List<Guid> IncomingTransactions { get; set; }
        public List<Guid> OutgoingTransactions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static AdvancedAccountDTO ConvertAccountDTO(AccountDTO account, List<Guid> incomingTransactions, List<Guid> outgoingTransactions)
        {
            return new AdvancedAccountDTO()
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                ClientId = account.ClientId,
                IncomingTransactions = incomingTransactions,
                OutgoingTransactions = outgoingTransactions,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            };
        }
    }
}
