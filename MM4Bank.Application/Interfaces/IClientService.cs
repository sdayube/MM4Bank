using MM4Bank.Application.DTOs;
using MM4Bank.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetClientsAsync();
        Task<ClientDTO> GetByIdAsync(Guid? id);
        Task<ClientDTO> GetByCPFAsync(CPF cpf);
        Task<ClientDTO> GetByNameAsync(Name name);
        Task<ClientDTO> GetClientAccountAsync(Guid? id);
        Task AddAsync(ClientDTO clientDTO);
        Task UpdateAsync(ClientDTO clientDTO);
        Task RemoveAsync(Guid? id);
    }
}
