namespace Web2Project.Dto
{
    public class KorisnikDto
    {
        public string KorisnickoIme { get; set ; }
        public string Lozinka { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string TipKoorisnika { get; set; }
        public bool Verifikovan { get; set; }
        public string Slika { get; set; }
        public string Email { get; set; }
        public double Novac { get; set; }
    }
}
