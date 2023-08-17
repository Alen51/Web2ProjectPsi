using static Web2Project.Enums.Enumerations;

namespace Web2Project.Models
{
    public class Porudzbina
    {
        public long Id { get; set; }
        public string Komentar { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumDostave { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public StanjePorudzbine StanjePorudzbine { get; set; }
        public double CenaPorudzbine { get; set; }
        public long KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        public List<ArtikalPorudzbine> ArtikliPorudzbine { get; set; }
    }
}
