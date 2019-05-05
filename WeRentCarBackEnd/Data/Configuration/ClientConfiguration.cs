using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.IdentificationNumber)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
