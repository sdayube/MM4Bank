using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string _password { get; private set; }
        public Password(string password)
        {
            if (IsValid(password))
            {
                _password = password;
            }
            throw new System.ArgumentException(nameof(password));
        }

    }
}
