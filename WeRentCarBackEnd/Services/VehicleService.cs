using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Services
{
    public interface IVehicleService : IRepository<Vehicle> { }
    public class VehicleService : Repository<Vehicle>, IVehicleService
    {
        public VehicleService(IDbFactory factory) : base(factory)
        {
        }
    }
}
