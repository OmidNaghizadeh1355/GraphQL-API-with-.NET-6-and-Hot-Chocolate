using CommanderGQL.Models;
using CommanderGQL.Data;
using StarWarAPI.Core;
using StarWarAPI.Entities;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        private readonly IStarWarApiService _StarWarApiService;

        public Query(IStarWarApiService StarWarApiService)
        {
            _StarWarApiService = StarWarApiService;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<StarShipFlight> GetStarShipFlight([ScopedService] AppDbContext context)
        {
            return context.StarShipFlights;
        }

        public IEnumerable<People> GetPersons()
        {
            return _StarWarApiService.GetAllPersons();
        }
    }
}
