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
    public class DetailsModel : PageModel
    {
        private readonly IOrder orderRepo;
        private readonly ICar carRepo;

        public DetailsModel(IOrder orderRepo, ICar carRepo)
        {
            this.orderRepo = orderRepo;
            this.carRepo = carRepo;
        }

        public Order Order { get; set; } = default!;
        public Car Car { get; set; }

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
                Car = await carRepo.GetByIdAsync(order.Car.CarId);
            }
            return Page();
        }
    }
}
