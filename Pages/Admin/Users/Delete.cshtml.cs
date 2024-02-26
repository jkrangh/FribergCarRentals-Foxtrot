using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUser userRep;

        public DeleteModel(IUser userRep)
        {
            this.userRep = userRep;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userRep.GetByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userRep.GetByIdAsync(id);
            
            if (user != null)
            {
                User = user;
                userRep.DeleteAsync(user);
            }

            return RedirectToPage("./Index");
        }
    }
}
