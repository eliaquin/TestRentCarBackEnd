using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IFileService _fileService;

        public VehiclesController(IVehicleService vehicleService, IFileService fileService)
        {
            _vehicleService = vehicleService;
            _fileService = fileService;
        }

        [HttpGet]
        [Route("getvehiclebyid/{id}")]
        public Vehicle GetVehicle(int id)
        {
            return _vehicleService.GetById(id);
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicleService.GetAll();
        }

        [HttpGet]
        [Route("getallvehiclesavailable")]
        public IEnumerable<Vehicle> GetAllVehiclesAvailable()
        {
            return _vehicleService.GetAllVehiclesAvailable();
        }

        [HttpGet]
        [Route("getallrentedvehicles")]
        public IEnumerable<Vehicle> GetAllVehiclesRented()
        {
            return _vehicleService.GetAllRentedVehicles();
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
        public async Task<ResponseInfo> AddVehicleImage()
        {
            if (!int.TryParse(Request.Headers["VehicleId"], out var vehicleId))
                return new ResponseInfo { OperationSuccessful = false, Message = "Expected header not received" };

            try
            {
                var file = Request.Form.Files.FirstOrDefault();
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                var saveFileSuccessful = await _fileService.SaveFile(file, fileName);
                var linkImageSuccessful = _vehicleService.TieImageToVehicle(vehicleId, fileName);

                var oInfo = new ResponseInfo();
                oInfo.OperationSuccessful = saveFileSuccessful && linkImageSuccessful;
                oInfo.Message = oInfo.OperationSuccessful ? "Archivo guardado exitosamente" : "Ocurrió un error al guardar el archivo";
                return oInfo;

            }
            catch (Exception e)
            {
                return new ResponseInfo { OperationSuccessful = false, Message = e.Message };
            }
        }

        [HttpPost]
        [Route("assignvehicletocustomer")]
        public ResponseInfo AssignVehicleToCustomer([FromBody]VehicleCustomerIds vehicleCustomerIds)
        {
            return _vehicleService.AssignVehicleToCustomer(vehicleCustomerIds);
        }
    }
}