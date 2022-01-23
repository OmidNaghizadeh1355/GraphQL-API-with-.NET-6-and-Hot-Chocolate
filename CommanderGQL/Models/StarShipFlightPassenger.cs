using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StarShipFlightId { get; set; }

        public StarShipFlight StarShipFlight { get; set; }

        [Required]
        public int PeopleId { get; set; }

        public People People { get; set; }
    }
}