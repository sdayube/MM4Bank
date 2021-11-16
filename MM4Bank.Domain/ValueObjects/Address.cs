using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string fullAddress)
        {
            if (IsValid(fullAddress))
            {
                SetFrom(fullAddress);
            }
            else
            {
                throw new System.ArgumentException(nameof(fullAddress));
            }
        }


        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

        public string FullAddress => GetFullAddress();

        private string GetFullAddress()
        {
            return $"{Country},{State},{City},{Neighbourhood},{Street},{Number},{Complement},{ZipCode}";
        }

        public void SetFrom(string fullAddress)
        {
            var address = fullAddress.Split(",");

            Country = address[0];
            // se não tem vírgulas os índices maiores que 0 são nulos
            // tem que pensar o que fazer aqui
            State = address[1];
            City = address[2];
            Neighbourhood = address[3];
            Street = address[4];
            Number = address[5];
            Complement = address[6];
            ZipCode = address[7];
        }

    }
}
