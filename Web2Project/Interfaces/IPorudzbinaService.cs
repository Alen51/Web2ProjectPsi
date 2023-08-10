using Web2Project.Dto;

namespace Web2Project.Interfaces
{
    public interface IPorudzbinaService
    {
        List<PorudzbinaDto> GetPorudzbine();
        PorudzbinaDto GetById(string id);
        PorudzbinaDto AddPorudzbina(PorudzbinaDto newPorudzbina);
        PorudzbinaDto UpdatePorudzbina(string id, PorudzbinaDto newPorudzbinaData);
        void deletePorudzbina(string email);
    }
}
