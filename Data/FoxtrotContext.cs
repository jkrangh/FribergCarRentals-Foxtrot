using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FribergCarRentals_Foxtrot.Models;

namespace FribergCarRentals_Foxtrot.Data
{
    public class FoxtrotContext : DbContext
    {
        public FoxtrotContext (DbContextOptions<FoxtrotContext> options)
            : base(options)
        {
        }

        public DbSet<FribergCarRentals_Foxtrot.Models.Car> Car { get; set; } = default!;
        public DbSet<FribergCarRentals_Foxtrot.Models.Category> Category { get; set; } = default!;
        public DbSet<FribergCarRentals_Foxtrot.Models.Order> Order { get; set; } = default!;
        public DbSet<FribergCarRentals_Foxtrot.Models.User> User { get; set; } = default!;
    }
}
