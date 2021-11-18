using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.DTOs
{
    public class DepositDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
    }
}
