using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MM4Bank.Domain.Entities;

namespace MM4Bank.Application.DTOs
{
    public class AccountDTO
    {
        public Guid Id { get; set; }

        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "Balance is required!")]
        public decimal Balance { get; set; }

        public Guid ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
