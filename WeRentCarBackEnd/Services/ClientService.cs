using AutoMapper;
using WeRentCarBackEnd.Data.Infrastructure;
using WeRentCarBackEnd.Dtos;
using WeRentCarBackEnd.Models;
using WeRentCarBackEnd.ViewModels;

namespace WeRentCarBackEnd.Services
{
    public interface IClientService : IRepository<Client>
    {
        ResponseInfo SaveClient(ClientDto client);
    }
    public class ClientService : Repository<Client>, IClientService
    {
        private readonly IMapper _mapper;

        public ClientService(IDbFactory factory, IMapper mapper) : base(factory)
        {
            _mapper = mapper;
        }

        public ResponseInfo SaveClient(ClientDto client)
        {
            var clientModel = _mapper.Map<Client>(client);

            if (Any(x => x.IdentificationNumber == clientModel.IdentificationNumber))
            {
                return new ResponseInfo { OperationSuccessful = false, Message = "Document already in use" };
            }

            Add(clientModel);
            var result = SaveChanges();

            var opInfo = new ResponseInfo();
            opInfo.OperationSuccessful = result > 0;
            opInfo.Message = opInfo.OperationSuccessful ? "Client sucessfully saved" : "Client save operation failed";

            return opInfo;
        }
    }
}
