using Microsoft.EntityFrameworkCore;

namespace Web2Project.Baza
{
    public class CRUD_Context: DbContext
    {
        public CRUD_Context(DbContextOptions<CRUD_Context> options) : base(options)
        
        {
        }

        public DbSet<Web2Project.Models.Korisnik> Korisnik { get; set; }
        public DbSet<Web2Project.Models.Paket> Paket { get; set; }
        public DbSet<Web2Project.Models.Porudzbina> Porudzbina { get; set; }
    }
}
