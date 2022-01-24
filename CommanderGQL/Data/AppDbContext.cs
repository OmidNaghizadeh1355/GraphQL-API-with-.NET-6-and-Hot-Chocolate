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
        public DbSet<Persson> Persson { get; set;}
        public DbSet<Passenger> Passengers { get; set;}
        public DbSet<Crew> Crews { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StarShipFlight>()
                .HasMany(p => p.Passengers)
                .WithOne(p => p.StarShipFlight!)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<Passenger>()
                .HasOne(p => p.StarShipFlight!)
                .WithMany(p => p.Passengers)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<StarShipFlight>()
                .HasMany(p => p.Crews)
                .WithOne(p => p.StarShipFlight!)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<Crew>()
                .HasOne(p => p.StarShipFlight!)
                .WithMany(p => p.Crews)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<Persson>()
                .HasMany(p => p.Passengers)
                .WithOne(p => p.Persson!)
                .HasForeignKey(p => p.PerssonId);

            modelBuilder
                .Entity<Passenger>()
                .HasOne(p => p.Persson!)
                .WithMany(p => p.Passengers)
                .HasForeignKey(p => p.PerssonId);

            modelBuilder
                .Entity<Persson>()
                .HasMany(p => p.Crews)
                .WithOne(p => p.Persson!)
                .HasForeignKey(p => p.PerssonId);

            modelBuilder
                .Entity<Crew>()
                .HasOne(p => p.Persson!)
                .WithMany(p => p.Crews)
                .HasForeignKey(p => p.PerssonId);

            modelBuilder.Entity<Crew>()
                .HasIndex(p => new {p.PerssonId , p.StarShipFlightId}).IsUnique();

            modelBuilder.Entity<Passenger>()
                .HasIndex(p => new {p.PerssonId , p.StarShipFlightId}).IsUnique();
        }
    }
}