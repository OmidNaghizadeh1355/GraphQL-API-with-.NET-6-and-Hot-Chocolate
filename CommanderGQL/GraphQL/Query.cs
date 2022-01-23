using CommanderGQL.Models;
using CommanderGQL.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<StarShipFlight> GetStarShipFlight([ScopedService] AppDbContext context)
        {
            return context.StarShipFlights;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Passenger> GetPassengers([ScopedService] AppDbContext context)
        {
            return context.Passengers;
        }
    }
}
