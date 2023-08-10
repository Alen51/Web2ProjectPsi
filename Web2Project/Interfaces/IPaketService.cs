using Web2Project.Dto;

namespace Web2Project.Interfaces
{
    public interface IPaketService
    {
        List<PaketDto> GetPakete();
        PaketDto GetById(string id);
        PaketDto AddPaket(PaketDto newPaket);
        PaketDto UpdatePaket(string id, PaketDto newPaketData);
        void deletePaket(string email);
    }
}
