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

namespace FribergCarRentals_Foxtrot.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly ICategory categoryRepo;

        public EditModel(ICategory categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category =  await categoryRepo.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            Category = category;
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
                if (Category != null)
                {
                    await categoryRepo.UpdateAsync(Category);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
