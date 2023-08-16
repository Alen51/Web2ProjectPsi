namespace Web2Project.Models
{
    public class ArtikalPorudzbine
    {
        public long Id { get; set; }
        public long ArtikalId { get; set; }
        public int Kolicina { get; set; }
        public long PorudzbinaId { get; set; }
        public Porudzbina Porudzbina { get; set; }
    }
}
