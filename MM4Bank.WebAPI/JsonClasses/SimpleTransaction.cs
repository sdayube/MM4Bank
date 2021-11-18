using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.JsonClasses
{
    public class SimpleTransaction
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
    }
}
