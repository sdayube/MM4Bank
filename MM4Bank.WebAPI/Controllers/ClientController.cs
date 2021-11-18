using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using MM4Bank.Domain.ValueObjects;
using MM4Bank.WebAPI.JsonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            var accounts = await _clientService.GetClientsAsync();

            if (accounts is null)
            {
                return NotFound("Accounts not found");
            }

            return Ok(accounts);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public async Task<ActionResult<ClientDTO>> GetById(Guid id)
        {
            var account = await _clientService.GetByIdAsync(id);

            if (account is null)
            {
                return NotFound("Client not found");
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> Create(ClientData clientData)
        {
            var clientDTO = ClientData.ConvertDataToDTO(clientData);

            var newClient = await _clientService.AddAsync(clientDTO);

            if (newClient is null)
            {
                return BadRequest("Client could not be created");
            }

            return new CreatedAtRouteResult("GetClient", new { id = newClient.Id }, newClient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientDTO>> Update(Guid id, ClientData clientData)
        {
            var clientDTO = ClientData.ConvertDataToDTO(clientData, id);

            var updatedClient = await _clientService.UpdateAsync(clientDTO);

            if (updatedClient is null)
            {
                return NotFound("Client not found");
            }

            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientDTO>> Delete(Guid id)
        {
            var client = await _clientService.GetByIdAsync(id);

            if (client is null)
            {
                return NotFound("Account not found");
            }


            await _clientService.RemoveAsync(id);

            return Ok(client);
        }
    }
}
