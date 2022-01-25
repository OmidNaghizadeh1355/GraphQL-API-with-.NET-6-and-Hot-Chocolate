using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Flight
{
    public record AddStarShipFlightPayLoad(StarShipFlight starShipFlight, IEnumerable<string> errorMessage);
}
