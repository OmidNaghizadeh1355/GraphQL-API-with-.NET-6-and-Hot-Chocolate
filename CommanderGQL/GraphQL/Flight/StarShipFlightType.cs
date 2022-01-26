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
                .Field(p => p.Crew)
                .ResolveWith<Resolvers>(p => p.GetCrewNumber(default!))
                .Description("Load Number od´f the Crew from StarWar API.");

            descriptor
                .Field(p => p.MaxPassengers)
                .ResolveWith<Resolvers>(p => p.GetMaxPassengers(default!))
                .Description("Load Max Passengers from StarWar API.");
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

            public int GetCrewNumber([Parent] StarShipFlight starShipFlight)
            {
                return _StarWarApiService.GetStarshipById(starShipFlight.StarshipId.ToString()).IntCrew;
            }

            public int GetMaxPassengers([Parent] StarShipFlight starShipFlight)
            {
                return _StarWarApiService.GetStarshipById(starShipFlight.StarshipId.ToString()).IntPassengers;
            }
        }
    }
}
