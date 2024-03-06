using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Customer.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrder orderRepo;

        public IndexModel(IOrder orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await orderRepo.GetAllOrdersAsync();
        }
    }
}
