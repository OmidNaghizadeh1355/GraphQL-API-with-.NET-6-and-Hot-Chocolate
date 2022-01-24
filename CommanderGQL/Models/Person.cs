using System.ComponentModel.DataAnnotations;
using CommanderGQL.Enums;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Fetch perssons from people controller")]
    public class Persson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

        public ICollection<Crew> Crews { get; set; } = new List<Crew>();
    }
}