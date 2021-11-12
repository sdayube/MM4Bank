using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MM4Bank.Domain.ValueObjects
{
    public class CPF
    {
        private readonly string _value;

        public CPF(string value)
        {
            _value = value;
        }

        public static bool TryParse(string value, out CPF result)
        {
            if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^\d{11}$"))
            {
                result = default;
                return false;
            }

            result = new CPF(value);
            return true;
        }

        public static CPF Parse(string value)
        {
            return (TryParse(value, out var result)) ? result : throw new System.ArgumentException(nameof(value));
        }

        public static implicit operator CPF(string value)
        {
            return Parse(value);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
