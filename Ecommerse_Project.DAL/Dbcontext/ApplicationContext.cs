using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.DAL.Entities;
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

    
            builder.Entity<CartProduct>().HasKey(a => new { a.ProductId, a.CartId });
            builder.Entity<CartProduct>().HasOne(a => a.Product).WithMany(a => a.Carts).HasForeignKey(a => a.ProductId);
            builder.Entity<CartProduct>().HasOne(a => a.Cart).WithMany(a => a.Products).HasForeignKey(c => c.CartId);

            builder.Entity<CustomerProductReview>().HasKey(a => new { a.ProductId,a.CustomerId });
            builder.Entity<CustomerProductReview>().HasOne(a => a.Product).WithMany(a => a.CustomerReviews).HasForeignKey(a=>a.ProductId);
            builder.Entity<CustomerProductReview>().HasOne(a => a.Customer).WithMany(a => a.ProductReviews).HasForeignKey(c => c.CustomerId);

            builder.Entity<WishListProduct>().HasKey(a => new { a.ProductId, a.WishlistId });
            builder.Entity<WishListProduct>().HasOne(a => a.Product).WithMany(a => a.WishLists).HasForeignKey(a => a.ProductId);
            builder.Entity<WishListProduct>().HasOne(a => a.Wishlist).WithMany(a => a.Products).HasForeignKey(c => c.WishlistId);

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

            //Product Seeding
            List<Product> products = new List<Product>
            { 

            // ----------- Men - T-Shirts (CategoryId = 4) -----------
            new Product
            {
                Id = 1,
                Name = "Nike Cotton T-Shirt",
                Description = "Comfortable and breathable cotton T-shirt, ideal for daily wear.",
                Price = 29.99m,
                Stock = 50,
                AddedAt = DateTime.Now,
                Brand = "Nike",
                Material = "Cotton",
                Color = "Black",
                Size = "M",
                CategoryId = 4,
                AdminID = 1
            },
            new Product
            {
                Id = 2,
                Name = "Adidas Polyester T-Shirt",
                Description = "Lightweight performance T-shirt made from premium polyester.",
                Price = 34.99m,
                Stock = 40,
                AddedAt = DateTime.Now,
                Brand = "Adidas",
                Material = "Polyester",
                Color = "White",
                Size = "L",
                CategoryId = 4,
                AdminID = 1
            },

            // ----------- Men - Shirts (CategoryId = 5) -----------
            new Product
            {
                Id = 3,
                Name = "Ralph Lauren Cotton Shirt",
                Description = "Elegant cotton shirt suitable for formal occasions.",
                Price = 79.99m,
                Stock = 30,
                AddedAt = DateTime.Now,
                Brand = "Ralph Lauren",
                Material = "Cotton",
                Color = "Light Blue",
                Size = "L",
                CategoryId = 5,
                AdminID = 1
            },
            new Product
            {
                Id = 4,
                Name = "Tommy Hilfiger Linen Shirt",
                Description = "Stylish and breathable linen shirt for summer days.",
                Price = 85.50m,
                Stock = 20,
                AddedAt = DateTime.Now,
                Brand = "Tommy Hilfiger",
                Material = "Linen",
                Color = "White",
                Size = "M",
                CategoryId = 5,
                AdminID = 1
            },

            // ----------- Men - Jeans (CategoryId = 6) -----------
            new Product
            {
                Id = 5,
                Name = "Levi's Denim Jeans",
                Description = "Classic fit jeans crafted from durable denim material.",
                Price = 69.99m,
                Stock = 60,
                AddedAt = DateTime.Now,
                Brand = "Levi's",
                Material = "Denim",
                Color = "Dark Blue",
                Size = "32",
                CategoryId = 6,
                AdminID = 1
            },
            new Product
            {
                Id = 6,
                Name = "Diesel Slim Fit Jeans",
                Description = "Trendy slim-fit jeans with a modern look.",
                Price = 99.99m,
                Stock = 25,
                AddedAt = DateTime.Now,
                Brand = "Diesel",
                Material = "Denim",
                Color = "Black",
                Size = "34",
                CategoryId = 6,
                AdminID = 1
            },

            // ----------- Men - Shoes (CategoryId = 7) -----------
            new Product
            {
                Id = 7,
                Name = "Nike Running Shoes",
                Description = "Lightweight running shoes with maximum cushioning.",
                Price = 120.00m,
                Stock = 35,
                AddedAt = DateTime.Now,
                Brand = "Nike",
                Material = "Synthetic",
                Color = "White",
                Size = "43",
                CategoryId = 7,
                AdminID = 1
            },
            new Product
            {
                Id = 8,
                Name = "Timberland Leather Boots",
                Description = "Durable leather boots designed for rough terrains.",
                Price = 150.00m,
                Stock = 20,
                AddedAt = DateTime.Now,
                Brand = "Timberland",
                Material = "Leather",
                Color = "Brown",
                Size = "44",
                CategoryId = 7,
                AdminID = 1
            },

            // ----------- Women - Dresses (CategoryId = 8) -----------
            new Product
            {
                Id = 9,
                Name = "Zara Summer Dress",
                Description = "Light cotton dress perfect for summer outings.",
                Price = 59.99m,
                Stock = 40,
                AddedAt = DateTime.Now,
                Brand = "Zara",
                Material = "Cotton",
                Color = "Red",
                Size = "M",
                CategoryId = 8,
                AdminID = 1
            },
            new Product
            {
                Id = 10,
                Name = "H&M Silk Evening Dress",
                Description = "Elegant silk evening dress for special occasions.",
                Price = 120.00m,
                Stock = 15,
                AddedAt = DateTime.Now,
                Brand = "H&M",
                Material = "Silk",
                Color = "Black",
                Size = "S",
                CategoryId = 8,
                AdminID = 1
            },

            // ----------- Women - Blouses (CategoryId = 9) -----------
            new Product
            {
                Id = 11,
                Name = "Mango Chiffon Blouse",
                Description = "Stylish chiffon blouse suitable for office and casual wear.",
                Price = 45.00m,
                Stock = 50,
                AddedAt = DateTime.Now,
                Brand = "Mango",
                Material = "Chiffon",
                Color = "Pink",
                Size = "S",
                CategoryId = 9,
                AdminID = 1
            },
            new Product
            {
                Id = 12,
                Name = "Forever 21 Cotton Blouse",
                Description = "Casual cotton blouse for everyday style.",
                Price = 35.00m,
                Stock = 45,
                AddedAt = DateTime.Now,
                Brand = "Forever 21",
                Material = "Cotton",
                Color = "White",
                Size = "M",
                CategoryId = 9,
                AdminID = 1
            },

            // ----------- Women - Skirts (CategoryId = 10) -----------
            new Product
            {
                Id = 13,
                Name = "Zara High Waist Skirt",
                Description = "Trendy high waist skirt for a modern chic look.",
                Price = 49.99m,
                Stock = 30,
                AddedAt = DateTime.Now,
                Brand = "Zara",
                Material = "Polyester",
                Color = "Black",
                Size = "M",
                CategoryId = 10,
                AdminID = 1
            },
            new Product
            {
                Id = 14,
                Name = "H&M Cotton Skirt",
                Description = "Comfortable and versatile cotton skirt.",
                Price = 39.99m,
                Stock = 25,
                AddedAt = DateTime.Now,
                Brand = "H&M",
                Material = "Cotton",
                Color = "Beige",
                Size = "S",
                CategoryId = 10,
                AdminID = 1
            },

            // ----------- Women - Heels (CategoryId = 11) -----------
            new Product
            {
                Id = 15,
                Name = "Aldo Leather Heels",
                Description = "Elegant leather heels perfect for formal events.",
                Price = 99.99m,
                Stock = 20,
                AddedAt = DateTime.Now,
                Brand = "Aldo",
                Material = "Leather",
                Color = "Nude",
                Size = "38",
                CategoryId = 11,
                AdminID = 1
            },
            new Product
            {
                Id = 16,
                Name = "Steve Madden Red Heels",
                Description = "Bold red heels to complete any party look.",
                Price = 110.00m,
                Stock = 15,
                AddedAt = DateTime.Now,
                Brand = "Steve Madden",
                Material = "Synthetic",
                Color = "Red",
                Size = "37",
                CategoryId = 11,
                AdminID = 1
            }
        };




            builder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                Name = "Admin User",
                Email = "admin@example.com",
                Password = "hashedpassword",
            });
            builder.Entity<Category>().HasData(categories);
            builder.Entity<Product>().HasData(products);
            


        }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Wishlist> Wishlist { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CustomerProductReview> CustomerProductReviews { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Paymen>Paymens { get; set; }
        public DbSet<TrackingDetails> TrackingDetails { get; set; } 
        public DbSet<WishListProduct> WishListProducts { get; set; }

    }
    
   
    
}
