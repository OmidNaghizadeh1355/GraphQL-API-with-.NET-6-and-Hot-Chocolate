using System.ComponentModel.DataAnnotations;
using CommanderGQL.Enums;

namespace CommanderGQL.Models
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public Gender gender { get; set; }

        [Required]
        public int StarShipFlightId { get; set; }

        public StarShipFlight starShipFlight { get; set; }
    }
}