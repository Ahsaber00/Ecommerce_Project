using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerse_Project.DAL.Entities
{
    public class WishListProductConfig : IEntityTypeConfiguration<WishListProduct>
    {
        public void Configure(EntityTypeBuilder<WishListProduct> builder)
        {

            builder.HasKey(a => new { a.ProductId, a.WishlistId });
            builder.HasOne(a => a.Product).WithMany(a => a.WishLists).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Wishlist).WithMany(a => a.Products).HasForeignKey(c => c.WishlistId);


            builder
.HasOne(wp => wp.Wishlist)
.WithMany(w => w.Products)
.HasForeignKey(wp => wp.WishlistId)
.OnDelete(DeleteBehavior.Restrict); // 👈 Prevent cascade cycle

            builder
    .HasOne(wp => wp.Product)
    .WithMany(p => p.WishLists)
    .HasForeignKey(wp => wp.ProductId)
    .OnDelete(DeleteBehavior.Restrict); // or Cascade if needed


        }
    }
}
