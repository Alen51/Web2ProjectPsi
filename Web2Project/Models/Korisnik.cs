

namespace Web2Project.Models
{
    public class Korisnik
    {
        private string email;
         
        private string korisnickoIme;

       

        private string lozinka;

        private string imeIPrezime;

        private DateTime datumRodjenja;

        private string adresa;

        private string tipKoorisnika;

        private bool verifikovan;

        private string slika;

        private double novac = 10000000;

        private List<Porudzbina> predhodnePorudzbine = new List<Porudzbina>();

        private List<Porudzbina> novePorudzbine= new List<Porudzbina>();    


        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string ImeIPrezime { get => imeIPrezime; set => imeIPrezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string TipKoorisnika { get => tipKoorisnika; set => tipKoorisnika = value; }
        public bool Verifikovan { get => verifikovan; set => verifikovan = value; }
        public string Slika { get => slika; set => slika = value; }
        public string Email { get => email; set => email = value; }
        public double Novac { get => novac; set => novac = value; }
        public List<Porudzbina> PredhodnePorudzbine { get => predhodnePorudzbine; set => predhodnePorudzbine = value; }
        public List<Porudzbina> NovePorudzbine { get => novePorudzbine; set => novePorudzbine = value; }
    }
}
