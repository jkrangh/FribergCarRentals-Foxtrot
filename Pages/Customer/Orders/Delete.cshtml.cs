using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Customer.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder orderRepo;

        public DeleteModel(IOrder orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderRepo.GetOrderByIdAsync(id);

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
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderRepo.GetOrderByIdAsync(id);
            if (order != null)
            {
                Order = order;
                await orderRepo.DeleteAsync(Order);
            }

            return RedirectToPage("./Index");
        }
    }
}
