using AutoMapper;
using Web2Project.Dto;
using Web2Project.Models;

namespace Web2Project.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Korisnik, KorisnikDto>().ReverseMap();
            CreateMap<Artikal, ArtikalDto>().ReverseMap();
            CreateMap<Porudzbina, PorudzbinaDto>().ReverseMap();
            CreateMap<Porudzbina, PorudzbinaPrikazDto>().ReverseMap();
            CreateMap<ArtikalPorudzbine, ArtikalPorudzbineDto>().ReverseMap();

        }
    }
}
