using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategory categoryRepo;

        public DeleteModel(ICategory categoryRepo)
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

            var category = await categoryRepo.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await categoryRepo.GetCategoryByIdAsync(id);
            if (category != null)
            {
                Category = category;
                await categoryRepo.DeleteAsync(Category);
            }

            return RedirectToPage("./Index");
        }
    }
}
