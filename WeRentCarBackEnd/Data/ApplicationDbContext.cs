﻿using Microsoft.EntityFrameworkCore;
using WeRentCarBackEnd.Data.Configuration;
using WeRentCarBackEnd.Models;

namespace WeRentCarBackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<TypeOfId> TypeOfId { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new TypeOfIdConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
