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
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync()
        {
            var transactionEntity = await _transactionRepository.GetTransactionsAsync(); ;
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactionEntity);
        }

        public async Task<TransactionDTO> GetByIdAsync(Guid? id)
        {
            var transactionEntity = await _transactionRepository.GetByIdAsync(id);
            return _mapper.Map<TransactionDTO>(transactionEntity);
        }
    }
}
