using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Flight
{
    public record AddStarShipFlightInput(int Id, 
        ICollection<AddPassengerInput>   Passengers,
        ICollection<AddCrewInput> Crew);

    public record AddPassengerInput(string Name);

    public record AddCrewInput(string Name);
}
