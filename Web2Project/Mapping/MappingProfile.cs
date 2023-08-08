using AutoMapper;
using Web2Project.Dto;
using Web2Project.Models;

namespace Web2Project.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            
            CreateMap<Korisnik,KorisnikDto>().ReverseMap();
            CreateMap<Paket,PaketDto>().ReverseMap();
            CreateMap<Porudzbina,PorudzbinaDto>().ReverseMap();
        
        }
    }
}
