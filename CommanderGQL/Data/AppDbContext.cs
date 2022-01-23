using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<StarShipFlight> StarShipFlights { get; set;}
        public DbSet<Passenger> Passengers { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StarShipFlight>()
                .HasMany(p => p.passengers)
                .WithOne(p => p.starShipFlight!)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<Passenger>()
                .HasOne(p => p.starShipFlight!)
                .WithMany(p => p.passengers)
                .HasForeignKey(p => p.StarShipFlightId);
        }
    }
}