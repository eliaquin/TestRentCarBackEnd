using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeRentCarBackEnd.Dtos;
using WeRentCarBackEnd.Models;
using WeRentCarBackEnd.Services;
using WeRentCarBackEnd.ViewModels;

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

        [HttpPost]
        [Route("savevehicle")]
        public ResponseInfo SaveVehicle([FromBody]VehicleDto vehicle)
        {
            return _vehicleService.SaveVehicle(vehicle);
        }

        [HttpPost]
        [Route("addvehicleimage")]
        [Consumes("multipart/form-data")]
        public ResponseInfo AddVehicleImage()
        {
            if (!int.TryParse(Request.Headers["VehicleId"], out var vehicleId))
                return new ResponseInfo { OperationSuccessful = false, Message = "Expected header not received" };

            try
            {
                var archivos = Request.Form.Files;
                foreach (var file in archivos)
                {
                    Console.WriteLine("Lego");
                }
            }
            catch (Exception e)
            {
                System.Console.Write(e);
            }
            return new ResponseInfo { OperationSuccessful = true, Message = "Test", Payload = vehicleId };
            throw new NotImplementedException();
        }
    }
}