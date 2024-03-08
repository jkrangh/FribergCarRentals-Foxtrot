// Your existing using statements...

using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRentals_Foxtrot.Pages.Customer.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICar carRep;
        private readonly IOrder orderRep;
        private readonly ICategory categoryRep;

        [BindProperty]
        public DateOnly StartDate { get; set; }

        [BindProperty]
        public DateOnly EndDate { get; set; }

        public IList<Car> Cars { get; set; }

        public List<Category> CarCategories { get; set; }
        public List<Order> Orders { get; set; }
        public List<Car> FilteredCars { get; set; }

        public IndexModel(ICar carRep, IOrder orderRep, ICategory categoryRep)
        {
            this.carRep = carRep;
            this.orderRep = orderRep;
            this.categoryRep = categoryRep;
        }

        public async Task OnGetAsync()
        {
            Cars = await carRep.GetAllAsync();
            Orders = await orderRep.GetAllOrdersAsync();
            CarCategories = await categoryRep.GetAllCategoriesAsync();
            FilteredCars = (List<Car>)await carRep.GetAllAsync();
        }

        public async Task OnPostAsync()
        {
            CarCategories = await carRep.GetCarCategoryAsync();

            if (ModelState.IsValid)
            {
                await LoadAvailableCars();
            }

            int categoryId;
            if (int.TryParse(Request.Form["CategoryFilter"], out categoryId))
            {
                FilteredCars = categoryId > 0
                    ? (await categoryRep.GetByCategoryAsync(categoryId)).ToList()
                    : Cars.ToList();
            }
            else
            {
                FilteredCars = Cars.ToList();
            }
        }
        


        private async Task LoadAvailableCars()
        {
            Cars = await carRep.GetAvailableCarsAsync(StartDate, EndDate);
        }

        
    }
}
