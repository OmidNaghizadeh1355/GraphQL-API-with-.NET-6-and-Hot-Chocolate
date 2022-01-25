using System.ComponentModel.DataAnnotations;
using CommanderGQL.Enums;

namespace CommanderGQL.Models
{
    [GraphQLDescription("A Crew belongs to a star ship flight and has many persons as crew member, No. of the crew has to be equal to the star flight specification.")]
    public class Crew
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StarShipFlightId { get; set; }

        public StarShipFlight StarShipFlight { get; set; }

        public string Persson { get; set; }
    }
}