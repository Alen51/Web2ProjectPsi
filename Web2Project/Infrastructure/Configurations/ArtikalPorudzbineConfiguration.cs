using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web2Project.Models;

namespace Web2Project.Infrastructure.Configurations
{
    public class ArtikalPorudzbineConfiguration : IEntityTypeConfiguration<ArtikalPorudzbine>
    {
        public void Configure(EntityTypeBuilder<ArtikalPorudzbine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Porudzbina)
                   .WithMany(x => x.ArtikliPorudzbine)
                   .HasForeignKey(x => x.PorudzbinaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
