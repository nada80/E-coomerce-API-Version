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
using AutoMapper;
using AutoMapper.Configuration;
using APi_version.Mapper;

namespace APi_version.Models
{
    public class AppDBContext : IdentityDbContext
    {
        protected readonly IMapper Mapper = Mapperconfig.mapper;
        protected readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly DbContext _context;
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
          
    }
   
       
        //private readonly DbContextOptions _options;
       
        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public DbSet<Product> Products { get; set; }
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
        


        //public DbSet<APi_version.Models.ApplicationUserModel> ApplicationUserModel { get; set; }





       
    }
}
