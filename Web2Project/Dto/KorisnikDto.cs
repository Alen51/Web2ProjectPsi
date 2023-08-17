using static Web2Project.Enums.Enumerations;

namespace Web2Project.Dto
{
    public class KorisnikDto
    {
        public long Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string Slika { get; set; }
        public StatusVerifikacije StatusVerifikacije { get; set; }
        public double CenaDostave { get; set; }
    }
}
