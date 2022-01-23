using CommanderGQL.Models;
using CommanderGQL.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<StarShipFlight> GetStarShipFlight([ScopedService] AppDbContext context)
        {
            return context.StarShipFlights;
        }
    }
}
