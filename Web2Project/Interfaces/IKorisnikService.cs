using Web2Project.Dto;

namespace Web2Project.Interfaces
{
    public interface IKorisnikService
    {
        List<KorisnikDto> GetKorisnike();
        KorisnikDto GetByEmail(string email);
        KorisnikDto AddKorisnik(KorisnikDto newKorisnik);
        KorisnikDto UpdateKorisnik(string email, KorisnikDto newKorisnikData);
        void deleteDorisnik(string email);
    }
}
