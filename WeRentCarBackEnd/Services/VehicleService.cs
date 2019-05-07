using AutoMapper;
using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Dtos;
using WeRentCarBackEnd.Models;
using WeRentCarBackEnd.ViewModels;

namespace WeRentCarBackEnd.Services
{
    public interface IVehicleService : IRepository<Vehicle>
    {
        ResponseInfo SaveVehicle(VehicleDto vehicle);
    }
    public class VehicleService : Repository<Vehicle>, IVehicleService
    {
        private readonly IMapper _mapper;

        public VehicleService(IDbFactory factory, IMapper mapper) : base(factory)
        {
            _mapper = mapper;
        }

        public ResponseInfo SaveVehicle(VehicleDto vehicleDto)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            Add(vehicle);
            var operationSuccessful = SaveChanges() > 0;
            return new ResponseInfo
            {
                OperationSuccessful = operationSuccessful,
                Message = "Vehicle was successfully created",
                Payload = vehicle.Id
            };
        }
    }
}
