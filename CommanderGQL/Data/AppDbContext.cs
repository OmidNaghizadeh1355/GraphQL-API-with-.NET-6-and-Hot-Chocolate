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
        public DbSet<People> People { get; set;}
        public DbSet<Passenger> Passengers { get; set;}
        public DbSet<Crew> Crews { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StarShipFlight>()
                .HasMany(p => p.passengers)
                .WithOne(p => p.StarShipFlight!)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<Passenger>()
                .HasOne(p => p.StarShipFlight!)
                .WithMany(p => p.passengers)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<StarShipFlight>()
                .HasMany(p => p.crews)
                .WithOne(p => p.StarShipFlight!)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<Crew>()
                .HasOne(p => p.StarShipFlight!)
                .WithMany(p => p.crews)
                .HasForeignKey(p => p.StarShipFlightId);

            modelBuilder
                .Entity<People>()
                .HasMany(p => p.passengers)
                .WithOne(p => p.People!)
                .HasForeignKey(p => p.PeopleId);

            modelBuilder
                .Entity<Passenger>()
                .HasOne(p => p.People!)
                .WithMany(p => p.passengers)
                .HasForeignKey(p => p.PeopleId);

            modelBuilder
                .Entity<People>()
                .HasMany(p => p.crews)
                .WithOne(p => p.People!)
                .HasForeignKey(p => p.PeopleId);

            modelBuilder
                .Entity<Crew>()
                .HasOne(p => p.People!)
                .WithMany(p => p.crews)
                .HasForeignKey(p => p.PeopleId);
        }
    }
}