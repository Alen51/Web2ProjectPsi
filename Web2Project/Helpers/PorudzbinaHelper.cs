using Web2Project.Baza;
using Web2Project.Dto;
using Web2Project.Models;

namespace Web2Project.Helpers
{
    public class PorudzbinaHelper
    {

        public static void UpdatePorudzbinaFields(Porudzbina porudzbina, PorudzbinaDto porudzbinaDto)
        {
            porudzbina.Komentar = porudzbinaDto.Komentar;
            porudzbina.Adresa = porudzbinaDto.Adresa;
            porudzbina.StanjePorudzbine = porudzbinaDto.StanjePorudzbine;
        }


        public static void ReturnKolicinaArtikalaPorudzbine(List<ArtikalPorudzbineDto> artikliPorudzbineDto, CRUD_Context _dbContext)
        {
            foreach (ArtikalPorudzbineDto artikalPorudzbineDto in artikliPorudzbineDto)
            {
                Artikal artikalPorudzbine = _dbContext.Artikli.Find(artikalPorudzbineDto.ArtikalId);
                if (artikalPorudzbine != null)
                {
                    artikalPorudzbine.Kolicina += artikalPorudzbineDto.Kolicina;
                }
            }
        }
    }
        
}
