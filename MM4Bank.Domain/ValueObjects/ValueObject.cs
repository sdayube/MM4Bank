using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected bool isValid(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return false;
            }
            return true;
        }
    }
}