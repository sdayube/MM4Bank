using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => getFullName();

        public Name(string fullName)
        {
            if (isValid(fullName))
            {
                setFrom(fullName);
            }
            throw new System.ArgumentException(nameof(fullName));
        }

        public void setFrom(string fullName)
        {
            var name = fullName.Split(" ");
            FirstName = name[0];
            LastName = name[1];
        }

        private string getFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
