namespace Web2Project.Dto
{
    public class PorudzbinaDto
    {
        public string Id { get; set; }
        public string ProdavacId { get; set; }
        public string KupacId { get; set; }
        public string Informacija { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public DateTime VremeDostave { get; set; }
    }
}
