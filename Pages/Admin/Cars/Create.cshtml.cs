using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Cars
{
    public class CreateModel : PageModel
    {   
        private readonly ICar carRep;
        private readonly ICategory catRep;

        public SelectList Categories { get; set; }
        public CreateModel(ICar carRep, ICategory catRep)
        {        
            this.carRep = carRep;
            this.catRep = catRep;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = new SelectList(await catRep.GetAllCategoriesAsync(), nameof(Category.CategoryId), nameof(Category.Name));

            return Page();
        }
       

        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Car.Category = await catRep.GetCategoryByIdAsync(Car.Category.CategoryId);

           await carRep.AddAsync(Car);            

            return RedirectToPage("./Index");
        }
    }
}
