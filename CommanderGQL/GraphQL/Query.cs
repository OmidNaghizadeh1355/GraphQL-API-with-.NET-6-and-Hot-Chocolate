using CommanderGQL.Models;
using CommanderGQL.Data;
using StarWarAPI.Core;
using StarWarAPI.Entities;

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

        [UseProjection]
        public IEnumerable<People> GetPersons([ScopedService] StarWarApiService context)
        {
            return context.GetAllPersons();
        }
    }
}
