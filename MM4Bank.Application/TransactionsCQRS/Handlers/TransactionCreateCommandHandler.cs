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
    public class TransactionCreateCommandHandler : IRequestHandler<TransactionCreateCommand, Transaction>
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionCreateCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction(request.Value, request.SourceAccount, request.TargetAccount, request.Type);

            if (transaction is null)
            {
                throw new ApplicationException("Error creating entity");
            }

            return await _transactionRepository.CreateAsync(transaction);
        }
    }
}
