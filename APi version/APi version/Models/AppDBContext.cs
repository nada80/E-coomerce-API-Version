using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APi_version.Models;

namespace APi_version.Models
{
    public class AppDBContext : DbContext
    {
        public class ApplicationUser : IdentityUser
        {

            public string Address { get; set; }

            public DateTime DateJoined { get; set; }

            public string Gender { get; set; }

            public string Country { get; set; }
            [Required]
            public bool isDeleted { get; set; }
            public virtual List<Payment> payments { get; set; }
        }
        private readonly DbContextOptions _options;
        public AppDBContext(DbContextOptions<AppDBContext> dbContextOptions)
        : base(dbContextOptions)
        {
          
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Cart> CartItem { get; set; }
        public DbSet<Brands> Brands { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Offers> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Payment> Payment { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }





        public DbSet<APi_version.Models.CartItem> CartItem_1 { get; set; }
    }
}
