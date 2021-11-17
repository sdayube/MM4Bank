using CleanArchMvc.Application.Accounts.Commands;
using MediatR;
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
    public class AccountUpdateCommandHandler : IRequestHandler<AccountUpdateCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountUpdateCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public /*async*/ Task<Account> Handle(AccountUpdateCommand request, CancellationToken cancellationToken)
        {
            //var account = await _accountRepository.GetByIdAsync(request.Id);

            //if (account is null)
            //{
            //    throw new ApplicationException("Entity could not be found");
            //}
            //else
            //{
            //    account.
            //}
            throw new NotImplementedException();
        }
    }
}
