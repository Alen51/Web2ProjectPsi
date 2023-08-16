using static Web2Project.Enums.Enumerations;

namespace Web2Project.Dto
{
    public class PorudzbinaDto
    {
       public long Id { get; set; }
        public string Komentar { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumDostave { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public StanjePorudzbine StanjePorudzbine { get; set; }
        public long KorisnikId { get; set; }
        public List<ArtikalPorudzbineDto> ArtikliPorudzbine { get; set; }
        public double CenaPorudzbine { get; set; }
    }
}
