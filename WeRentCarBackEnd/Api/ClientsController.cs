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
        private readonly ITypeOfIdService _typeOfIdService;

        public ClientsController(IClientService clientService, ITypeOfIdService typeOfIdService)
        {
            _clientService = clientService;
            _typeOfIdService = typeOfIdService;
        }

        [HttpGet]
        [Route("getallclients")]
        public IEnumerable<Client> GetAllClients()
        {
            return _clientService.GetAll();
        }

        [HttpGet]
        [Route("getalltypesofid")]
        public IEnumerable<TypeOfId> GetAllTypesOfId()
        {
            return _typeOfIdService.GetAll();
        }
    }
}