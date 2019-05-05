using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Services
{
    public interface IClientService : IRepository<Client> { }
    public class ClientService : Repository<Client>, IClientService
    {
        public ClientService(IDbFactory factory) : base(factory)
        {
        }
    }
}
