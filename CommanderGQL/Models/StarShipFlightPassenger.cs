using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    [GraphQLDescription("A Passenger belongs to a star ship flight and has many persons as passengers, The MAX No. of the passengers has to follow the star flight specification.")]
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StarShipFlightId { get; set; }

        public StarShipFlight StarShipFlight { get; set; }

        [Required]
        public int PerssonId { get; set; }

        public Persson Persson { get; set; }
    }
}