using AutoMapper;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Application.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsAsync()
        {
            var accountsEntity = await _accountRepository.GetAccountsAsync();
            return _mapper.Map<IEnumerable<AccountDTO>>(accountsEntity);
        }

        public async Task<AccountDTO> GetByIdAsync(Guid? id)
        {
            var accountEntity = await _accountRepository.GetByIdAsync(id);
            return _mapper.Map<AccountDTO>(accountEntity);
        }

        public async Task AddAsync(AccountDTO accountDTO)
        {
            var accountEntity = _mapper.Map<Account>(accountDTO);
            await _accountRepository.CreateAsync(accountEntity);
        }

        public async Task UpdateAsync(AccountDTO accountDTO)
        {
            var accountEntity = _mapper.Map<Account>(accountDTO);
            await _accountRepository.UpdateAsync(accountEntity);
        }

        public async Task RemoveAsync(Guid? id)
        {
            var accountEntity = _accountRepository.GetByIdAsync(id).Result;
            await _accountRepository.RemoveAsync(accountEntity);
        }
    }
}
