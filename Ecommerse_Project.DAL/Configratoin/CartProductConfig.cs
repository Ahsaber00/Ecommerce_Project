using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerse_Project.DAL.Models;
namespace Ecommerse_Project.DAL.Entities
{
    public class CartProductConfig : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(a => new { a.ProductId, a.CartId });
            builder.HasOne(a => a.Product).WithMany(a => a.Carts).HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.Cart).WithMany(a => a.Products).HasForeignKey(c => c.CartId).OnDelete(DeleteBehavior.Restrict);

            ;

        }
    }
}
