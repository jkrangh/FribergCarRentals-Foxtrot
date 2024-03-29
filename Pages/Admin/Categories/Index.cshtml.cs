﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly ICategory categoryRepo;

        public IndexModel(ICategory categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await categoryRepo.GetAllCategoriesAsync();
        }
    }
}
