using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Customer.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrder orderRepo;
        private readonly ICar carRepo;
        private readonly IUser userRepo;

        public CreateModel(IOrder orderRepo, ICar carRepo, IUser userRepo)
        {
            this.orderRepo = orderRepo;
            this.carRepo = carRepo;
            this.userRepo = userRepo;
        }

        public async Task<IActionResult> OnGet(int carId)
        {
            Car = await carRepo.GetByIdAsync(carId);
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        [BindProperty]
        public Car Car { get; set; }
        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            int? currentUserId = HttpContext.Session.GetInt32("UserId");
            User user = await userRepo.GetByIdAsync(currentUserId);
            Car car = await carRepo.GetByIdAsync(Car.CarId);
            
            Order order = new Order
            {
                User = user,
                Car = car,
                StartDate = Order.StartDate,
                EndDate = Order.EndDate,
                IsActive = true
            };

            car.IsAvailable = false;

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            await orderRepo.AddAsync(order);

            return RedirectToPage("./Index");
        }
    }
}
