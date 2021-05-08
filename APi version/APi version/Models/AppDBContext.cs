using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APi_version.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace APi_version.Models
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }
        public class ApplicationUser : IdentityUser
        {
            
          
            [Column(TypeName = "nvarchar(150)")]
            public string FullName { get; set; }
            [Required]
            public string Role { get; set; }
        }
       
        private readonly DbContextOptions _options;
       
        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Brands> Brands { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Offers> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
        


        public DbSet<APi_version.Models.ApplicationUserModel> ApplicationUserModel { get; set; }





       
    }
}
