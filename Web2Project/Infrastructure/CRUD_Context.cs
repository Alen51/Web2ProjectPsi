using Microsoft.EntityFrameworkCore;
using Web2Project.Models;

namespace Web2Project.Baza
{
    public class CRUD_Context: DbContext
    {
        

        public DbSet<Porudzbina> Korisnik { get; set; }
        public DbSet<Paket> Paket { get; set; }
        public DbSet<Porudzbina> Porudzbina { get; set; }

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
