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
        [UseFiltering]
        [UseSorting]
        public IQueryable<StarShipFlight> GetStarShipFlight([ScopedService] AppDbContext context)
        {
            return context.StarShipFlights;
        }

        [UseFiltering]
        [UseSorting]
        public IQueryable<People> GetPersons()
        {
            return _StarWarApiService.GetAllPersons();
        }

        [UseFiltering]
        [UseSorting]
        public IQueryable<Starship> GetStarships()
        {
            return _StarWarApiService.GetAllStarships();
        }
    }
}
