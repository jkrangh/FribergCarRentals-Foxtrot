using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals_Foxtrot.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Bilkategori")]
        public string Name { get; set; }

    }
}
