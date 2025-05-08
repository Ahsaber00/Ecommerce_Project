using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Models.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse_Project.DAL.Dbcontext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            
            builder.ApplyConfiguration(new WishListProductConfig());
          

            //category seeding





            var passwordHasher = new PasswordHasher<ApplicationUser>();


            var adminUser = new Admin
            {
                UserName = "Admin",
                Email = "Admin@mail.com",



            };


            // Hash the password and set it to the PasswordHash property
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, " ");

            // Seed the admin user into the database
            builder.Entity<Admin>().HasData(adminUser);
            //category seeding
            List<Category> categories = new List<Category>()
            {
                 new Category { Id = 1, Name = "Men", ParentCategoryId = null },
                 new Category { Id = 2, Name = "Women", ParentCategoryId = null },
                 new Category { Id = 4, Name = "T-Shirts", ParentCategoryId = 1 },
                 new Category { Id = 5, Name = "Shirts", ParentCategoryId = 1 },
                 new Category { Id = 6, Name = "Jeans", ParentCategoryId = 1 },
                 new Category { Id = 7, Name = "Shoes", ParentCategoryId = 1 },
                 new Category { Id = 8, Name = "Dresses", ParentCategoryId = 2 },
                 new Category { Id = 9, Name = "Blouses", ParentCategoryId = 2 },
                 new Category { Id = 10, Name = "Skirts", ParentCategoryId = 2 },
                 new Category { Id = 11, Name = "Heels", ParentCategoryId = 2 },
            };

    
            builder.Entity<Category>().HasData(categories);
            
           







        }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Wishlist> Wishlist { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Paymen>Paymens { get; set; }
        public DbSet<TrackingDetails> TrackingDetails { get; set; } 
        public DbSet<WishListProduct> WishListProducts { get; set; }


        // Add these new DbSet entries for the order-related models
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

    }
    
   
    
}
