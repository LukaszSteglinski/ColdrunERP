using ColdrunERP.Core.Enums;
using ColdrunERP.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Data.Contexts
{
    public class TruckDbContext : DbContext
    {
        public DbSet<TruckEntity> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TruckDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TruckEntity>()
                .HasKey(t => t.Id); 

            modelBuilder.Entity<TruckEntity>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TruckEntity>()
                .HasIndex(t => t.Id)
                .IsUnique();

            // Seed the database with some example data
            modelBuilder.Entity<TruckEntity>().HasData(
                new TruckEntity { Id = 1, Code = "1", Name = "Truck1", Status = TruckStatus.AtJob, Description = "Truck 1" },
                new TruckEntity { Id = 2, Code = "2", Name = "Pickup1", Status = TruckStatus.AtJob, Description = "Pickip 1" },
                new TruckEntity { Id = 3, Code = "3", Name = "Truck2", Status = TruckStatus.OutOfService, Description = "Truck 2" }
            );
        }
    }
}
