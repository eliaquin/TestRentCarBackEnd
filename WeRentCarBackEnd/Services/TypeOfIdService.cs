using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Services
{
    public interface ITypeOfIdService : IRepository<TypeOfId>
    {

    }
    public class TypeOfIdService : Repository<TypeOfId>, ITypeOfIdService
    {
        public TypeOfIdService(IDbFactory factory) : base(factory)
        {
        }
    }
}
