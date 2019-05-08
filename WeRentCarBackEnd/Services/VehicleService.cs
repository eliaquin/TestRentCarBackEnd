using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Dtos;
using WeRentCarBackEnd.Models;
using WeRentCarBackEnd.ViewModels;

namespace WeRentCarBackEnd.Services
{
    public interface IVehicleService : IRepository<Vehicle>
    {
        ResponseInfo SaveVehicle(VehicleDto vehicle);
        bool TieImageToVehicle(int vehicleId, string imageName);
        IEnumerable<Vehicle> GetAllVehiclesAvailable();
        IEnumerable<Vehicle> GetAllRentedVehicles();
        ResponseInfo AssignVehicleToCustomer(VehicleCustomerIds vehicleCustomerIds);

    }
    public class VehicleService : Repository<Vehicle>, IVehicleService
    {
        private readonly IMapper _mapper;

        public VehicleService(IDbFactory factory, IMapper mapper) : base(factory)
        {
            _mapper = mapper;
        }

        public override IEnumerable<Vehicle> GetAll()
        {
            return base.GetAll().Where(x => !string.IsNullOrEmpty(x.ImageName));
        }

        public bool TieImageToVehicle(int vehicleId, string imageName)
        {
            var vehicle = GetById(vehicleId);
            vehicle.ImageName = imageName;
            return SaveChanges() > 0;
        }

        public ResponseInfo SaveVehicle(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            vehicle.DateOfCreation = DateTime.Now;
            Add(vehicle);
            var operationSuccessful = SaveChanges() > 0;
            return new ResponseInfo
            {
                OperationSuccessful = operationSuccessful,
                Message = "Vehicle was successfully created",
                Payload = vehicle.Id
            };
        }
        public IEnumerable<Vehicle> GetAllVehiclesAvailable()
        {
            return GetMany(x => !string.IsNullOrEmpty(x.ImageName) && x.ClientId == null);
        }

        public IEnumerable<Vehicle> GetAllRentedVehicles()
        {
            return GetMany(x => !string.IsNullOrEmpty(x.ImageName) && x.ClientId != null);
        }

        public ResponseInfo AssignVehicleToCustomer(VehicleCustomerIds vehicleCustomerIds)
        {
            var vehicle = GetById(vehicleCustomerIds.VehicleId);
            var client = Context.Clients.Find(vehicleCustomerIds.CustomerId);

            if (vehicle != null && vehicle.ClientId == null && client != null)
            {
                vehicle.ClientId = client.Id;
                if (SaveChanges() > 0)
                    return new ResponseInfo { OperationSuccessful = true, Message = $"{vehicle.Brand} {vehicle.Model} successfully assigned to {client.FirstName} {client.LastName}" };
                else
                    return new ResponseInfo { OperationSuccessful = false, Message = "Save operation failed" };
            }

            return new ResponseInfo { OperationSuccessful = false, Message = "Vehicle not available" };
        }
    }
}
