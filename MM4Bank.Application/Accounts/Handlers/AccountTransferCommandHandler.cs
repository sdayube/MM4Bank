using MediatR;
using MM4Bank.Application.Accounts.Commands;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MM4Bank.Application.Accounts.Handlers
{
    class AccountTransferCommandHandler : IRequestHandler<AccountTransferCommand, Transaction>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountTransferCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Transaction> Handle(AccountTransferCommand request, CancellationToken cancellationToken)
        {
            var sourceAccount = await _accountRepository.GetByIdAsync(request.Id)
                ?? throw new ApplicationException("Source account could not be found");

            var targetAccount = await _accountRepository.GetByIdAsync(request.TargetId)
                ?? throw new ApplicationException("Target account could not be found");

            var transaction = sourceAccount.SendTransfer(request.Value, targetAccount);
            return transaction;
        }
    }
}
