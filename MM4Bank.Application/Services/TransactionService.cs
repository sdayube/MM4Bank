using AutoMapper;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
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
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync()
        {
            var transactionsEntity = await _transactionRepository.GetTransactionsAsync();
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactionsEntity);
        }

        public async Task<TransactionDTO> GetByIdAsync(Guid? id)
        {
            var transactionEntity = await _transactionRepository.GetByIdAsync(id);
            return _mapper.Map<TransactionDTO>(transactionEntity);
        }
    }
}
