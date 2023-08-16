using Web2Project.Dto;

namespace Web2Project.Interfaces
{
    public interface IArtikalService
    {
        Task<ArtikalDto> AddArtikal(ArtikalDto newArtikalDto);
        Task<List<ArtikalDto>> GetAllArtikals();
        Task<ArtikalDto> GetArtikalById(long id);
        Task<ArtikalDto> UpdateArtikal(long id, ArtikalDto updateArtikalDto);
        Task<bool> DeleteArtikal(long id);
        Task<List<ArtikalDto>> GetProdavceveArtikle(long id);
    }
}
