using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MM4Bank.Application.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Account Number is required!")]
        public int AccountNumber { get; set; }
        
        [Required(ErrorMessage="Balance is required!")]
        public decimal Balance { get; set; }
        
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public List<Transaction> Deposits { get; set; }
        public List<Transaction> Withdrawals { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
