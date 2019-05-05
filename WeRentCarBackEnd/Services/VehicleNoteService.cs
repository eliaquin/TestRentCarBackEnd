using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Services
{
    public interface IVehicleNoteService : IRepository<VehicleNote> { }
    public class VehicleNoteService : Repository<VehicleNote>, IVehicleNoteService
    {
        public VehicleNoteService(IDbFactory factory) : base(factory)
        {
        }
    }
}
