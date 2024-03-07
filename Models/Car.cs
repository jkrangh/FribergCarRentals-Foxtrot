using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_Foxtrot.Models
{
    public class Car
    {

        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }

        public string? Description { get; set; }

        public string? Picture { get; set; }

        public bool IsAvailable { get; set; } = true;
        [Required]
        public int Price { get; set; }
        [Required]
        public Category Category { get; set; }


    }
}
