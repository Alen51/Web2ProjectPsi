namespace Web2Project.Models
{
    public class Artikal
    {
        public Artikal(){}

        public long Id;
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public double CenaDostave { get; set; }
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public string Fotografija { get; set; }
        public long ProdavacId { get; set; }
        public Korisnik Prodavac { get; set; }
        
    }
}
