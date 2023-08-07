using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Web2Project.Models
{
    public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            builder.HasKey(x => x.Email);

            builder.Property(x => x.Email).ValueGeneratedOnAdd();

            builder.Property(x => x.KorisnickoIme).HasMaxLength(40);

            builder.Property(x => x.Adresa).HasMaxLength(40);

            builder.Property(x => x.TipKoorisnika).HasMaxLength(15);

            builder.HasMany(x => x.NovePorudzbine);

            builder.HasMany(x => x.PredhodnePorudzbine);
                   
        }
    }
}
