using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_Foxtrot.Models
{
    public class Car
    {
        [Display(Name = "Bil ID")]
        public int CarId { get; set; }
        [Required]
        [Display(Name = "Tillverkare")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Modell")]
        public string Model { get; set; }
        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }
        [Display(Name = "Bildlänk")]
        public string? Picture { get; set; }
        [Display(Name = "Tillgänglig")]
        public bool IsAvailable { get; set; } = true;
        [Required]
        [Display(Name = "Pris/dag")]

        public int Price { get; set; }
        [Required]
        public Category Category { get; set; }

    }
}
