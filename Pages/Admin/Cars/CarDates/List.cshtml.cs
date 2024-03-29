﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Data;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Pages.Admin.Cars.CarDates
{
    public class IndexModel : PageModel
    {
       
        private readonly IOrder orderRep;
        private readonly ICar carRep;

        public IndexModel(IOrder orderRep, ICar carRep)
        {           
            this.orderRep = orderRep;
            this.carRep = carRep;
        }

        public IList<Order> Order { get;set; } = default!;
        [BindProperty]
        public DateOnly StartDate { get; set; }
        [BindProperty]
        public DateOnly EndDate { get; set; }

        public async Task OnGetAsync(Order order)
        {
            StartDate = order.StartDate;
            EndDate = order.EndDate;

            var list = await orderRep.GetAllOrdersCategoryAsync();          
            //Order = list2.ToList();
            Order = list.Where(s => s.StartDate <= EndDate && s.EndDate >= StartDate).Where(u=>u.Car.IsAvailable == true).ToList();
            
            //Order = list2.Where(s => (s.StartDate <= EndDate) && (s.StartDate <= StartDate) && (s.EndDate <= EndDate) && (s.EndDate >= StartDate)).ToList();

            //Order = list2.Where(s => s.EndDate <= EndDate && s.EndDate >= StartDate).ToList();

        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var car = await carRep.GetByIdAsync(id);
            car.IsAvailable = false;
            await carRep.UpdateAsync(car);

            return RedirectToPage("./Index");

        }
    }
}
