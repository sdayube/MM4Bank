using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.JsonClasses
{
    public class Transfer
    {
        public Guid SourceId { get; set; }
        public Guid TargetId { get; set; }
        public decimal Value { get; set; }

    }
}
