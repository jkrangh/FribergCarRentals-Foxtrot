using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Orders
{
    public class EditModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly IUser userRep;

        [BindProperty]
        public Order Order { get; set; }

        public EditModel(IOrder orderRep, ICar carRep, IUser userRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.userRep = userRep;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = await orderRep.GetOrderByIdAsync(id);

            if (Order == null)
            {
                return NotFound();
            }

            Order.Car = await carRep.GetByIdAsync(id);
            Order.User = await userRep.GetByIdAsync(id);

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            //Order.Car = await carRep.Order.CarId(id);
            //Order.User = await userRep.Order.UserId(id);

            orderRep.UpdateAsync(Order);

            return RedirectToPage("/Index");
        }
    }
}
