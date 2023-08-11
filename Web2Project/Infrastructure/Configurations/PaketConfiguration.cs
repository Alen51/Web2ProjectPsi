using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web2Project.Models;

namespace Web2Project.Infrastructure.Configurations
{
    public class PaketConfiguration : IEntityTypeConfiguration<Paket>
    {
        public void Configure(EntityTypeBuilder<Paket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
