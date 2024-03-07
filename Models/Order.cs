using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_Foxtrot.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public Car Car { get; set; }
        public User User { get; set; }
        [Display(Name = "Aktiv")]
        public bool IsActive { get; set; } = true;
        [Display(Name = "Startdatum")]
        public DateOnly StartDate { get; set; }
        [Display(Name = "Slutdatum")]
        public DateOnly EndDate { get; set; }

    }
}
