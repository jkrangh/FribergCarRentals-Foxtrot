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

        public IndexModel(ICar carRep)
        {
            this.carRep = carRep;
        }
        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await carRep.GetAllAsync();
        }
    }
}
