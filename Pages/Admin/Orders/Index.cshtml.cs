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

        private readonly IOrder orderRep;

        public IndexModel(IOrder orderRep)
        {
            
            this.orderRep = orderRep;
        }
        public IEnumerable<Order> ActiveOrders { get; set; }
        public IEnumerable<Order> InactiveOrders { get; set;}




        public async Task OnGetAsync()
        {
            if (orderRep != null)
            {
                ActiveOrders = await orderRep.GetActiveOrdersAsync();
                InactiveOrders = await orderRep.GetInactiveOrdersAsync();
            }
        }
    }
}
