using System.ComponentModel.DataAnnotations;
using CommanderGQL.Enums;

namespace CommanderGQL.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        public ICollection<Passenger> passengers { get; set; } = new List<Passenger>();

        public ICollection<Crew> crews { get; set; } = new List<Crew>();
    }
}