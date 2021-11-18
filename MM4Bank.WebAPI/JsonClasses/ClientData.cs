using MM4Bank.Application.DTOs;
using MM4Bank.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.JsonClasses
{
    public class ClientData
    {
        public string Name { get; set; }

        public string CPF { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public static ClientDTO ConvertDataToDTO(ClientData clientData)
        {
            return new ClientDTO()
            {
                Id = Guid.NewGuid(),
                Name = new Name(clientData.Name),
                CPF = new CPF(clientData.CPF),
                AccountId = Guid.Empty,
                Address = new Address(clientData.Address),
                Password = new Password(clientData.Password)
            };
        }
    }
}
