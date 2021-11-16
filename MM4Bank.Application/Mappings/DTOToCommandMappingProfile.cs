using AutoMapper;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Transactions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<TransactionDTO, TransactionCreateCommand>();
        }
    }
}
