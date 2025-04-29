using Microsoft.EntityFrameworkCore;
using GardenVariety.Models;

namespace GardenVariety.Data
{
    public class GardenVarietyContext : DbContext
    {
        public GardenVarietyContext(DbContextOptions<GardenVarietyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Garden>().HasData(
                new Garden
                {
                    GardenId = 1,
                    Name = "Apple",
                    Type = ProduceType.Vegetable,
                    Quantity = 10,
                    PlantingDate = new DateTime(2025, 2, 27),
                    Notes = "Fresh and juicy apples."
                },
                new Garden
                {
                    GardenId = 2,
                    Name = "Carrot",
                    Type = ProduceType.Vegetable,
                    Quantity = 30,
                    PlantingDate = new DateTime(2025, 1, 27),
                    Notes = "Crunchy and sweet carrots."
                }
            );

            modelBuilder.Entity<Harvester>().HasData(
                new Harvester
                {
                    Id = 1,
                    GardenId = 1,
                    Date = new DateTime(2025, 8, 14)
                },
                new Harvester
                {
                    Id = 2,
                    GardenId = 2,
                    Date = new DateTime(2025, 9, 15)
                }
            );
        }

        public DbSet<GardenVariety.Models.Harvester> Harvests { get; set; } = default!;
        public DbSet<GardenVariety.Models.Garden> Gardens { get; set; } = default!;
    }
}
