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

namespace FribergCarRentals_Foxtrot.Pages.Admin.Cars
{
    public class EditModel : PageModel
    {  
        private readonly ICar carRep;

        public EditModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car =  await carRep.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }         

            try
            {
                if(Car != null)
                {
                    await carRep.UpdateAsync(Car);
                }               
            }
            catch (DbUpdateConcurrencyException)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }

        //private bool CarExists(int id)
        //{
        //    return carRep.Ge(e => e.CarId == id);
        //}
    }
}
