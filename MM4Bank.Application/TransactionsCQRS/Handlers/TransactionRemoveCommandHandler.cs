using MediatR;
using MM4Bank.Application.Transactions.Commands;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MM4Bank.Application.Transactions.Handlers
{
    public class TransactionRemoveCommandHandler : IRequestHandler<TransactionRemoveCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionRemoveCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> Handle(TransactionRemoveCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);

            if (transaction is null)
            {
                throw new ApplicationException("Entity not found");
            }

            return await _transactionRepository.RemoveAsync(transaction);
        }
    }
}
