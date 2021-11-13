using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MM4Bank.Domain.ValueObjects;
using MM4Bank.Domain.Entities;

namespace MM4Bank.Application.DTOs
{
    public class ClientDTO
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public Name Name { get; set; }

        [Required(ErrorMessage = "CPF is required!")]
        public CPF CPF { get; set; }

        [Required(ErrorMessage = "Account is required!")]
        public Account Account { get; set; }

        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "Address is required!")]
        public Address Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
