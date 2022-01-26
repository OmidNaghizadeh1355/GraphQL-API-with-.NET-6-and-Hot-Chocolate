using StarWarAPI.Entities;

namespace CommanderGQL.GraphQL.Flight
{
    public class StarShipType : ObjectType<Starship>
    {
        protected override void Configure(IObjectTypeDescriptor<Starship> descriptor)
        {
            descriptor.Description("Loaded from StarWar API.");
        }
    }
}
