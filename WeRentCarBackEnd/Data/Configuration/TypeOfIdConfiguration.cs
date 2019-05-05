using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Data.Configuration
{
    public class TypeOfIdConfiguration : IEntityTypeConfiguration<TypeOfId>
    {
        public void Configure(EntityTypeBuilder<TypeOfId> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(new List<TypeOfId> {
                new TypeOfId
                {
                    Id = 1,
                    Name = "Identification Card"
                },
                new TypeOfId
                {
                    Id = 2,
                    Name = "Passport"
                }
            });
        }
    }
}
