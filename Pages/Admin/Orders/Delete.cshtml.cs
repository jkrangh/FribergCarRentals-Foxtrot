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
    public class DeleteModel : PageModel
    {
        private readonly IOrder orderRep;

        public DeleteModel(IOrder orderRep)
        {
            
            this.orderRep = orderRep;
        }

        [BindProperty]
        public Order Order { get; set; } 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderRep.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                Order = await orderRep.GetOrderByIdAsync(id);
                if (Order != null)
                {
                    Order.IsActive = false;
                    await orderRep.UpdateAsync(Order);
                }
            }
            catch (Exception)
            {

                return RedirectToPage("/Error");
            }



            return RedirectToPage("/Admin/Orders/Index");
        }
    }
}
