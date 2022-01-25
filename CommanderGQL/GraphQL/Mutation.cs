using CommanderGQL.Data;
using CommanderGQL.GraphQL.Flight;
using CommanderGQL.Models;
using StarWarAPI.Core;
using StarWarAPI.Entities;

namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        private readonly IStarWarApiService _StarWarApiService;
        private readonly IValidationResult _ValidationResult;

        public Mutation(IStarWarApiService starWarApiService, IValidationResult validationResult)
        {
            _StarWarApiService = starWarApiService;
            _ValidationResult = validationResult;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddStarShipFlightPayLoad> AddStarShipFlight(
            AddStarShipFlightInput input, 
            [ScopedService] AppDbContext context)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var StarShipFlight = new StarShipFlight
                {
                    FlightNo = input.FlightNo
                };

                var starWarPersons = _StarWarApiService.GetAllPersons();

                ValidatingPassengers(input, starWarPersons);
                ValidatingTheCrew(input, starWarPersons);

                context.StarShipFlights.Add(StarShipFlight);

                await context.SaveChangesAsync();
                await SavePassengers(input, context, StarShipFlight);
                await SaveTheCrew(input, context, StarShipFlight);

                if (!_ValidationResult.IsValid)
                {
                    transaction.Rollback();
                    return new AddStarShipFlightPayLoad(StarShipFlight, _ValidationResult.Messages);
                }
                else
                {
                    transaction.Commit();
                    _ValidationResult.AddErrorMessage($"OK");
                    _ValidationResult.IsValid = true;
                    return new AddStarShipFlightPayLoad(StarShipFlight, _ValidationResult.Messages);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _ValidationResult.AddErrorMessage(ex.Message);
                _ValidationResult.IsValid = true;
                return new AddStarShipFlightPayLoad(new StarShipFlight(), _ValidationResult.Messages);
            }

            
        }

        public class MutationType : ObjectType<Mutation>
        {
            protected override void Configure(
                IObjectTypeDescriptor<Mutation> descriptor)
            {
                descriptor.Field(f => f.AddStarShipFlight(default, default));
            }
        }

        private void ValidatingTheCrew(AddStarShipFlightInput input, IEnumerable<People> starWarPersons)
        {
            foreach (var item in input.Crew.Where(item => !starWarPersons.Any(person => person.name == item.Name)))
            {
                _ValidationResult.AddErrorMessage($"persson : {item.Name} is not exist as an crew member in Star war.");
                _ValidationResult.IsValid = false;
            }
        }

        private void ValidatingPassengers(AddStarShipFlightInput input, IEnumerable<People> starWarPersons)
        {
            foreach (var item in input.Passengers.Where(item => !starWarPersons.Any(person => person.name == item.Name)))
            {
                _ValidationResult.AddErrorMessage($"passenger: {item.Name} is not exist as an passenger in Star war.");
                _ValidationResult.IsValid = false;
            }
        }

        private static async Task SavePassengers(AddStarShipFlightInput input, AppDbContext context, StarShipFlight StarShipFlight)
        {
            foreach (var item in input.Passengers.Where(item => !context.Passengers.Any(p => p.Persson == item.Name && p.StarShipFlightId == StarShipFlight.Id)))
            {
                context.Passengers.Add(new Passenger { StarShipFlightId = StarShipFlight.Id, Persson = item.Name });
                await context.SaveChangesAsync();
            }
        }

        private static async Task SaveTheCrew(AddStarShipFlightInput input, AppDbContext context, StarShipFlight StarShipFlight)
        {
            foreach (var item in input.Crew.Where(item => !context.Crews.Any(p => p.Persson == item.Name && p.StarShipFlightId == StarShipFlight.Id)))
            {
                context.Crews.Add(new Crew { StarShipFlightId = StarShipFlight.Id, Persson = item.Name });
                await context.SaveChangesAsync();
            }
        }
    }
}
