using MM4Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetByIdAsync(Guid? id);
        Task<Client> GetClientAccountAsync(Guid? id);
        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<Client> RemoveAsync(Client client);
    }
}
