using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Star Ship Flight is combination of passengers and crews!")]
    public class StarShipFlight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int starshipId { get; set; }

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

        public ICollection<Crew> Crews { get; set; } = new List<Crew>();
    }
}