﻿using Microsoft.EntityFrameworkCore;
using MM4Bank.Domain.Entities;
using MM4Bank.Domain.Interfaces;
using MM4Bank.Domain.ValueObjects;
using MM4Bank.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MM4Bank.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        ApplicationDbContext _clientContext;

        public ClientRepository(ApplicationDbContext context)
        {
            _clientContext = context;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _clientContext.Add(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetByIdAsync(Guid? id)
        {
            return await _clientContext.Clients.Include(a => a.Account).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> GetByCPFAsync(CPF cpf)
        {
            return await _clientContext.Clients.SingleOrDefaultAsync(c => c.CPF == cpf);
        }

        public async Task<Client> GetByNameAsync(Name name)
        {
            return await _clientContext.Clients.SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Client> GetClientAccountAsync(Guid? id)
        {
            return await _clientContext.Clients.Include(c => c.Account).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientContext.Clients.ToListAsync();
        }

        public async Task<Client> RemoveAsync(Client client)
        {
            _clientContext.Remove(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _clientContext.Update(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }
    }
}
