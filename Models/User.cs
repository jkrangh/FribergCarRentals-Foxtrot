using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_Foxtrot.Models
{
    public class User
    {
        [Display(Name = "Användar ID")]
        public int UserId { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        [Display(Name = "Admin användare")]
        public bool IsAdmin { get; set; } = false;

        public virtual List<Order> Orders { get; set; }
    }
}
