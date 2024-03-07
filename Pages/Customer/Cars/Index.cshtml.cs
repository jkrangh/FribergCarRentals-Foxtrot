using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Customer.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICar carRep;
        private readonly IOrder orderRep;
        [BindProperty]
        public DateOnly StartDate { get; set; }

        [BindProperty]
        public DateOnly EndDate { get; set; }

        public IList<Car> Cars { get; set; }
        public List<Category> CarCategories { get; set; }
        public List<Order> Orders { get; set; }

        public IndexModel(ICar carRep, IOrder orderRep)
        {
            this.carRep = carRep;
            this.orderRep = orderRep;
        }

        public async Task OnGetAsync()
        {
            
            Cars = await carRep.GetAllAsync();
            Orders = await orderRep.GetAllOrdersAsync();
        }
        public async Task OnPostAsync()
        {
            CarCategories = await carRep.GetCarCategoryAsync();

            if (ModelState.IsValid)
            {
                await LoadAvailableCars();
            }
        }
        private async Task LoadAvailableCars()
        {
            Cars = await carRep.GetAvailableCarsAsync(StartDate, EndDate);
        }

    }

}
