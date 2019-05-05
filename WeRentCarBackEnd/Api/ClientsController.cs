using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WeRentCarBackEnd.Models;
using WeRentCarBackEnd.Services;

namespace WeRentCarBackEnd.Api
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
        [Route("getallclients")]
        public IEnumerable<Client> GetAllClients()
        {
            return _clientService.GetAll();
        }
    }
}