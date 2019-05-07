using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.Brand)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Color)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.Model)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.ImageName)
                .HasMaxLength(512);
            builder.Property(x => x.DailyPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
