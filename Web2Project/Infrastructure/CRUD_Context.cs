using Microsoft.EntityFrameworkCore;
using Web2Project.Models;

namespace Web2Project.Baza
{
    public class CRUD_Context: DbContext
    {


        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Porudzbina> Porudzbine { get; set; }
        public DbSet<ArtikalPorudzbine> ArtikliUPorudzbinama { get; set; }

        public CRUD_Context(DbContextOptions options) : base(options)

        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Kazemo mu da pronadje sve konfiguracije u Assembliju i da ih primeni nad bazom
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRUD_Context).Assembly);
        }
    }
}
