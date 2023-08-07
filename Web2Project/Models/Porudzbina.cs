namespace Web2Project.Models
{
    public class Porudzbina
    {
        private string prodavacId;

        private string kupacId;

        private string informacija;

        private int kolicina;

        private double cena;

        private DateTime vremeDostave;

        private List<Paket> artikli = new List<Paket>();

        public string ProdavacId { get => prodavacId; set => prodavacId = value; }
        public string KupacId { get => kupacId; set => kupacId = value; }
        public string Informacija { get => informacija; set => informacija = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public double Cena { get => cena; set => cena = value; }
        public DateTime VremeDostave { get => vremeDostave; set => vremeDostave = value; }
        public List<Paket> Artikli { get => artikli; set => artikli = value; }
    }
}
