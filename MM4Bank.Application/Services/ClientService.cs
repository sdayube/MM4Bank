using AutoMapper;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using MM4Bank.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDTO>> GetClientsAsync()
        {
            var clientEntity = await _clientRepository.GetClientsAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(clientEntity);
        }

        public async Task<ClientDTO> GetByIdAsync(Guid? id)
        {
            var clientEntity = await _clientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(clientEntity);
        }

        public async Task<ClientDTO> GetByCPFAsync(CPF cpf)
        {
            var clientEntity = await _clientRepository.GetByCPFAsync(cpf);
            return _mapper.Map<ClientDTO>(clientEntity);
        }

        public async Task<ClientDTO> GetByNameAsync(Name name)
        {
            var clientEntity = await _clientRepository.GetByNameAsync(name);
            return _mapper.Map<ClientDTO>(clientEntity);
        }

        public async Task<ClientDTO> GetClientAccountAsync(Guid? id)
        {
            var clientEntity = await _clientRepository.GetClientAccountAsync(id);
            return _mapper.Map<ClientDTO>(clientEntity);
        }

        public async Task<ClientDTO> AddAsync(ClientDTO clientDTO)
        {
            var allCPFs = await GetClientsAsync();

            if (allCPFs.Any<ClientDTO>(c => c.CPF == clientDTO.CPF))
            {
                throw new InvalidOperationException("A client with this CPF already exists");
            }

            var clientEntity = _mapper.Map<Client>(clientDTO);

            var clientWithAccountId = await _clientRepository.CreateAsync(clientEntity);

            return _mapper.Map<ClientDTO>(clientWithAccountId);
        }

        public async Task<ClientDTO> UpdateAsync(ClientDTO clientDTO)
        {
            var clientEntity = _mapper.Map<Client>(clientDTO);
            var clientLinked = await _clientRepository.UpdateAsync(clientEntity);

            return _mapper.Map<ClientDTO>(clientLinked);
        }

        public async Task<ClientDTO> RemoveAsync(Guid? id)
        {
            var clientEntity = _clientRepository.GetByIdAsync(id).Result;
            await _clientRepository.RemoveAsync(clientEntity);

            return _mapper.Map<ClientDTO>(clientEntity);
        }
    }
}
