using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Orders
{
    public class IndexModel : PageModel
    {
        private readonly FribergCarRentals_Foxtrot.Data.FoxtrotContext _context;

        public IndexModel(FribergCarRentals_Foxtrot.Data.FoxtrotContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Order.ToListAsync();
        }
    }
}
