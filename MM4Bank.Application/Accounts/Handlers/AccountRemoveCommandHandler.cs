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
    public class AccountRemoveCommandHandler : IRequestHandler<AccountRemoveCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountRemoveCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(AccountRemoveCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account is null)
            {
                throw new ApplicationException("Entity not found");
            }

            return await _accountRepository.RemoveAsync(account);
        }
    }
}
