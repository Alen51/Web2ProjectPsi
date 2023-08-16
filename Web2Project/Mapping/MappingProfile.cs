using AutoMapper;
using Web2Project.Dto;
using Web2Project.Models;

namespace Web2Project.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            
            CreateMap<Porudzbina,KorisnikDto>().ReverseMap();
            CreateMap<Artikal,ArtikalDto>().ReverseMap();
            CreateMap<Porudzbina,PorudzbinaDto>().ReverseMap();
        
        }
    }
}
