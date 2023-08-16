using Web2Project.Dto;

namespace Web2Project.Interfaces
{
    public interface IKorisnikService
    {
        Task<KorisnikDto> AddKorisnik(KorisnikDto newKorisnikDto);
        Task<List<KorisnikDto>> GetAllKorisnik();
        Task<KorisnikDto> GetKorisnikById(long id);
        Task<KorisnikDto> UpdateKorisnik(long id, KorisnikDto updateKorisnikDto);
        Task DeleteKorisnik(long id);

        Task<ResponseDto> Login(LoginKorisnikDto loginKorisnikDto);
        Task<ResponseDto> Registration(KorisnikDto registerKorisnik);


        Task<List<KorisnikDto>> GetProdavce();
        Task<List<KorisnikDto>> VerifyProdavce(long id, string statusVerifikacije);
    }
}
