using Microsoft.AspNetCore.Mvc;
using MM4Bank.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM4Bank.WebUI.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await _clientService.GetClientsAsync();
            return View(accounts);
        }
    }
}
