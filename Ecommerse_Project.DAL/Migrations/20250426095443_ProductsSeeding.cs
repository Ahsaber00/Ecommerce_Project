using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductsSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@example.com", "Admin User", "hashedpassword" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedAt", "AdminID", "Brand", "CategoryId", "Color", "Description", "Material", "Name", "Price", "Size", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(293), 1, "Nike", 4, "Black", "Comfortable and breathable cotton T-shirt, ideal for daily wear.", "Cotton", "Nike Cotton T-Shirt", 29.99m, "M", 50 },
                    { 2, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(338), 1, "Adidas", 4, "White", "Lightweight performance T-shirt made from premium polyester.", "Polyester", "Adidas Polyester T-Shirt", 34.99m, "L", 40 },
                    { 3, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(341), 1, "Ralph Lauren", 5, "Light Blue", "Elegant cotton shirt suitable for formal occasions.", "Cotton", "Ralph Lauren Cotton Shirt", 79.99m, "L", 30 },
                    { 4, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(344), 1, "Tommy Hilfiger", 5, "White", "Stylish and breathable linen shirt for summer days.", "Linen", "Tommy Hilfiger Linen Shirt", 85.50m, "M", 20 },
                    { 5, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(347), 1, "Levi's", 6, "Dark Blue", "Classic fit jeans crafted from durable denim material.", "Denim", "Levi's Denim Jeans", 69.99m, "32", 60 },
                    { 6, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(350), 1, "Diesel", 6, "Black", "Trendy slim-fit jeans with a modern look.", "Denim", "Diesel Slim Fit Jeans", 99.99m, "34", 25 },
                    { 7, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(353), 1, "Nike", 7, "White", "Lightweight running shoes with maximum cushioning.", "Synthetic", "Nike Running Shoes", 120.00m, "43", 35 },
                    { 8, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(356), 1, "Timberland", 7, "Brown", "Durable leather boots designed for rough terrains.", "Leather", "Timberland Leather Boots", 150.00m, "44", 20 },
                    { 9, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(359), 1, "Zara", 8, "Red", "Light cotton dress perfect for summer outings.", "Cotton", "Zara Summer Dress", 59.99m, "M", 40 },
                    { 10, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(362), 1, "H&M", 8, "Black", "Elegant silk evening dress for special occasions.", "Silk", "H&M Silk Evening Dress", 120.00m, "S", 15 },
                    { 11, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(364), 1, "Mango", 9, "Pink", "Stylish chiffon blouse suitable for office and casual wear.", "Chiffon", "Mango Chiffon Blouse", 45.00m, "S", 50 },
                    { 12, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(367), 1, "Forever 21", 9, "White", "Casual cotton blouse for everyday style.", "Cotton", "Forever 21 Cotton Blouse", 35.00m, "M", 45 },
                    { 13, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(369), 1, "Zara", 10, "Black", "Trendy high waist skirt for a modern chic look.", "Polyester", "Zara High Waist Skirt", 49.99m, "M", 30 },
                    { 14, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(372), 1, "H&M", 10, "Beige", "Comfortable and versatile cotton skirt.", "Cotton", "H&M Cotton Skirt", 39.99m, "S", 25 },
                    { 15, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(374), 1, "Aldo", 11, "Nude", "Elegant leather heels perfect for formal events.", "Leather", "Aldo Leather Heels", 99.99m, "38", 20 },
                    { 16, new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(377), 1, "Steve Madden", 11, "Red", "Bold red heels to complete any party look.", "Synthetic", "Steve Madden Red Heels", 110.00m, "37", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
