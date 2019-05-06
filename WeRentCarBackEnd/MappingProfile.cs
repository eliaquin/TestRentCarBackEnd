using AutoMapper;
using WeRentCarBackEnd.Dtos;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientDto, Client>()
                .ForMember(x => x.IdentificationNumber, y => y.MapFrom(z => z.IdNumber))
                .ReverseMap();
        }
    }
}
