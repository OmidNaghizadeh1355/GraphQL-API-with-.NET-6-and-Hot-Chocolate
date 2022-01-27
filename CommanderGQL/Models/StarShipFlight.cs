using StarWarAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models
{
    
    public class StarShipFlight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StarshipId { get; set; }

        [NotMapped]
        public Starship Starship { get; set; }

        [NotMapped]
        public Boolean IsValid { get; set; }

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

        public ICollection<Crew> Crews { get; set; } = new List<Crew>();
    }
}