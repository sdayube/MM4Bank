using AutoMapper;
using MediatR;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using MM4Bank.Application.Transactions.Commands;
using MM4Bank.Application.Transactions.Queries;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TransactionService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync()
        {
            var query = new GetTransactionsQuery() ?? throw new ApplicationException("Entities could not be loaded");
            var transactionEntity = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<TransactionDTO>>(transactionEntity);
        }

        public async Task<TransactionDTO> GetByIdAsync(Guid? id)
        {
            var query = new GetTransactionByIdQuery(id.Value) ?? throw new ApplicationException("Entity could not be loaded");
            var transactionEntity = await _mediator.Send(query);

            return _mapper.Map<TransactionDTO>(transactionEntity);
        }

        public async Task AddAsync(TransactionDTO transactionDTO)
        {
            var command = _mapper.Map<TransactionCreateCommand>(transactionDTO);
            await _mediator.Send(command);
        }

        public async Task RemoveAsync(Guid? id)
        {
            var command = new TransactionRemoveCommand(id.Value) ?? throw new ApplicationException("Entity could not be loaded");
            await _mediator.Send(command);
        }
    }
}
