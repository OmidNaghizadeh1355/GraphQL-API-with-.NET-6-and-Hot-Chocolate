using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class StarShipFlight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FlightNo { get; set; }
    }
}