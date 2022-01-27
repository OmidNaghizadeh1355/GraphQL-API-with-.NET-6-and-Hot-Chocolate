using CommanderGQL.Data;
using CommanderGQL.Models;
using StarWarAPI.Core;
using StarWarAPI.Entities;

namespace CommanderGQL.GraphQL.Flight
{
    public class StarShipFlightType : ObjectType<StarShipFlight>
    {
        protected override void Configure(IObjectTypeDescriptor<StarShipFlight> descriptor)
        {
            descriptor.Description("Star Ship Flight need to have a Starship, passengers and crews!");

            descriptor
                .Field(p => p.Starship)
                .ResolveWith<Resolvers>(p => p.GetStarship(default!))
                .Description("Load from StarWar API.");

            descriptor
                .Field(p => p.Passengers)
                .ResolveWith<Resolvers>(p => p.GetPassengers(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Load from DB");

            descriptor
                .Field(p => p.Crews)
                .ResolveWith<Resolvers>(p => p.GetCrew(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Load from DB");

            descriptor
                .Field(p => p.IsValid)
                .ResolveWith<Resolvers>(p => p.IsValid(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Load from DB");
        }

        private class Resolvers
        {
            private readonly IStarWarApiService _StarWarApiService;

            public Resolvers(IStarWarApiService starWarApiService)
            {
                _StarWarApiService = starWarApiService;
            }

            public Starship GetStarship([Parent] StarShipFlight starShipFlight)
            {
                return _StarWarApiService.GetStarshipById(starShipFlight.StarshipId.ToString());  
            }

            public IQueryable<Passenger> GetPassengers([Parent] StarShipFlight starShipFlight, [ScopedService] AppDbContext context)
            {
                return context.Passengers.Where(p => p.StarShipFlightId == starShipFlight.Id);
            }

            public IQueryable<Crew> GetCrew([Parent] StarShipFlight starShipFlight, [ScopedService] AppDbContext context)
            {
                return context.Crews.Where(p => p.StarShipFlightId == starShipFlight.Id);
            }

            public Boolean IsValid([Parent] StarShipFlight starShipFlight, [ScopedService] AppDbContext context)
            {
                var starShip = _StarWarApiService.GetStarshipById(starShipFlight.StarshipId.ToString());
                var RegisteredCrewNo  = context.Crews.Count(p => p.StarShipFlightId == starShipFlight.StarshipId);
                var RegistedPassengers = context.Passengers.Count(p => p.StarShipFlightId == starShipFlight.StarshipId);

                if (starShip.IntCrew == RegisteredCrewNo && starShip.IntPassengers >= RegistedPassengers)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
