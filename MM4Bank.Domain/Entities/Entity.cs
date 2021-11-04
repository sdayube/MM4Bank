using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime creadtedAt { get; protected set; } = DateTime.Now;
    }
}
