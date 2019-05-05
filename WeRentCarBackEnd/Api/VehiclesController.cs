using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WeRentCarBackEnd.Models;
using WeRentCarBackEnd.Services;

namespace WeRentCarBackEnd.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("getallvehicles")]
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicleService.GetAll();
        }
    }
}