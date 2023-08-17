using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web2Project.Models;

namespace Web2Project.Infrastructure.Configurations
{
    public class PaketConfiguration : IEntityTypeConfiguration<Artikal>
    {
        public void Configure(EntityTypeBuilder<Artikal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Naziv).HasMaxLength(100);
            builder.Property(x => x.Opis).HasMaxLength(5000);

            builder.HasOne(x => x.Prodavac)
                   .WithMany(x => x.ProdavceviArtikli)
                   .HasForeignKey(x => x.ProdavacId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
