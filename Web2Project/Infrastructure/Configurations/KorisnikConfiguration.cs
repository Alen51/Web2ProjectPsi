using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web2Project.Models;

namespace Web2Project.Infrastructure.Configurations
{
    public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
             builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.KorisnickoIme).HasMaxLength(50);
            builder.Property(x => x.Ime).HasMaxLength(30);
            builder.Property(x => x.Prezime).HasMaxLength(30);
            builder.HasIndex(x => x.Email).IsUnique();

        }
    }
}
