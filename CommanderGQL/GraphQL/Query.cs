using CommanderGQL.Models;
using CommanderGQL.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        public IQueryable<StarShipFlight> GetStarShipFlight([Service] AppDbContext context)
        {
            return context.StarShipFlights;
        }
    }
}
