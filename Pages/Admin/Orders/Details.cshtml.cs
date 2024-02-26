using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly IUser userRep;
        public DetailsModel(IOrder orderRep, ICar carRep, IUser userRep)
        {

            this.orderRep = orderRep;
            this.carRep = carRep;
            this.userRep = userRep;
        }

        public Order Order { get; set; } 

        public async Task<IActionResult> OnGetAsync(int id)
        {
           Order = await orderRep.GetOrderByIdAsync(id);
           if(Order == null)
            {
                return NotFound();
            }
           else
            {
                Order.Car = carRep.GetByIdAsync(Order.CarId);
                Order.User = userRep.GetByIdAsync(Order.UserId);
                return Page();
            }
            
            

        }
    }
}
