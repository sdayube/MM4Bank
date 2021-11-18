using Microsoft.AspNetCore.Mvc;
using MM4Bank.Application.DTOs;
using MM4Bank.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            var categories = await _clientService.GetClientsAsync();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:Guid}", Name = "GetClient")]
        public async Task<ActionResult<ClientDTO>> Get(Guid id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound("Client not found");
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDto)
        {
            if (clientDto == null)
                return BadRequest("Invalid Data");

            await _clientService.AddAsync(clientDto);

            return new CreatedAtRouteResult("GetClient", new { id = clientDto.Id }, 
                clientDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id,[FromBody] ClientDTO clientDto)
        {
            if (id != clientDto.Id)
                return BadRequest();

            if (clientDto == null)
                return BadRequest();

            await _clientService.UpdateAsync(clientDto);

            return Ok(clientDto);
        }          
        
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ClientDTO>> Delete(Guid id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if(client == null)
            {
                return NotFound("Client not found");
            }
            
            await _clientService.RemoveAsync(id);

            return Ok(client);

        }
    }
}