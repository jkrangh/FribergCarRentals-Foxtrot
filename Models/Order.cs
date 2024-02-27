namespace FribergCarRentals_Foxtrot.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public Car Car { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; } = true;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

    }
}
