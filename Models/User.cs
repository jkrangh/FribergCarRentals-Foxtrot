using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_Foxtrot.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;

        public virtual List<Order> Orders { get; set; }
    }
}
