using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web2Project.Models;

namespace Web2Project.Infrastructure.Configurations
{
    public class PorudzbinaConfiguration : IEntityTypeConfiguration<Porudzbina>
    {
        public void Configure(EntityTypeBuilder<Porudzbina> builder)
        {
             builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Komentar).HasMaxLength(5000);

            builder.HasOne(x => x.Korisnik)
                   .WithMany(x => x.Porudzbine)
                   .HasForeignKey(x => x.KorisnikId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
