namespace Web2Project.Models
{
    public class Paket
    {
        private string id;

        private string naziv;

        private double cena;

        private int kolicina;

        private string opis;

        private string slika;

        

        public string Naziv { get => naziv; set => naziv = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public string Opis { get => opis; set => opis = value; }
        public string Slika { get => slika; set => slika = value; }
        public string Id { get => id; set => id = value; }
        
    }
}
