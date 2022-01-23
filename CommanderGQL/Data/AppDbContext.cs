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
    }
}