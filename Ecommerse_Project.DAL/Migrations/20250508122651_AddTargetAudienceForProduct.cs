using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTargetAudienceForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c71c593b-289a-4197-9bcf-c3da824c980c");

            migrationBuilder.AddColumn<int>(
                name: "TargetAudience",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12ef705b-af21-4b03-ada7-a14fb66965a1", 0, "1ee9f878-b60c-4898-8281-a938612c13d3", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEMtyRGbtIIUbnVhI+ju8MdWA9LPTN+mdAtDTpXjZQ01aCHZGl4/2uR4Wr/zxI/wl0w==", null, false, 0, "eb6df624-24fb-41bc-a998-5d23d3eb0d3f", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12ef705b-af21-4b03-ada7-a14fb66965a1");

            migrationBuilder.DropColumn(
                name: "TargetAudience",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c71c593b-289a-4197-9bcf-c3da824c980c", 0, "439935a7-f4d1-4b9a-b6ee-55b2247113ee", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEOBZdMhY+A+aw2v9qywy5SXxLxz4uqCeIU1h8EQ5v5JuZ5S4cOkpdQnzoJgtZ5FB4Q==", null, false, 0, "9c9734eb-bf40-42a0-83bd-b603e0e60cc9", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedAt", "AdminId", "Brand", "CategoryId", "Color", "Description", "Material", "ModifiedAt", "ModifiedBy", "Name", "Price", "Size", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7404), "c71c593b-289a-4197-9bcf-c3da824c980c", "Nike", 4, "Black", "Comfortable and breathable cotton T-shirt, ideal for daily wear.", "Cotton", null, null, "Nike Cotton T-Shirt", 29.99m, "M", 50 },
                    { 2, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7463), "c71c593b-289a-4197-9bcf-c3da824c980c", "Adidas", 4, "White", "Lightweight performance T-shirt made from premium polyester.", "Polyester", null, null, "Adidas Polyester T-Shirt", 34.99m, "L", 40 },
                    { 3, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7467), "c71c593b-289a-4197-9bcf-c3da824c980c", "Ralph Lauren", 5, "Light Blue", "Elegant cotton shirt suitable for formal occasions.", "Cotton", null, null, "Ralph Lauren Cotton Shirt", 79.99m, "L", 30 },
                    { 4, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7471), "c71c593b-289a-4197-9bcf-c3da824c980c", "Tommy Hilfiger", 5, "White", "Stylish and breathable linen shirt for summer days.", "Linen", null, null, "Tommy Hilfiger Linen Shirt", 85.50m, "M", 20 },
                    { 5, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7474), "c71c593b-289a-4197-9bcf-c3da824c980c", "Levi's", 6, "Dark Blue", "Classic fit jeans crafted from durable denim material.", "Denim", null, null, "Levi's Denim Jeans", 69.99m, "32", 60 },
                    { 6, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7478), "c71c593b-289a-4197-9bcf-c3da824c980c", "Diesel", 6, "Black", "Trendy slim-fit jeans with a modern look.", "Denim", null, null, "Diesel Slim Fit Jeans", 99.99m, "34", 25 },
                    { 7, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7480), "c71c593b-289a-4197-9bcf-c3da824c980c", "Nike", 7, "White", "Lightweight running shoes with maximum cushioning.", "Synthetic", null, null, "Nike Running Shoes", 120.00m, "43", 35 },
                    { 8, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7483), "c71c593b-289a-4197-9bcf-c3da824c980c", "Timberland", 7, "Brown", "Durable leather boots designed for rough terrains.", "Leather", null, null, "Timberland Leather Boots", 150.00m, "44", 20 },
                    { 9, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7486), "c71c593b-289a-4197-9bcf-c3da824c980c", "Zara", 8, "Red", "Light cotton dress perfect for summer outings.", "Cotton", null, null, "Zara Summer Dress", 59.99m, "M", 40 },
                    { 10, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7490), "c71c593b-289a-4197-9bcf-c3da824c980c", "H&M", 8, "Black", "Elegant silk evening dress for special occasions.", "Silk", null, null, "H&M Silk Evening Dress", 120.00m, "S", 15 },
                    { 11, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7494), "c71c593b-289a-4197-9bcf-c3da824c980c", "Mango", 9, "Pink", "Stylish chiffon blouse suitable for office and casual wear.", "Chiffon", null, null, "Mango Chiffon Blouse", 45.00m, "S", 50 },
                    { 12, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7497), "c71c593b-289a-4197-9bcf-c3da824c980c", "Forever 21", 9, "White", "Casual cotton blouse for everyday style.", "Cotton", null, null, "Forever 21 Cotton Blouse", 35.00m, "M", 45 },
                    { 13, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7640), "c71c593b-289a-4197-9bcf-c3da824c980c", "Zara", 10, "Black", "Trendy high waist skirt for a modern chic look.", "Polyester", null, null, "Zara High Waist Skirt", 49.99m, "M", 30 },
                    { 14, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7644), "c71c593b-289a-4197-9bcf-c3da824c980c", "H&M", 10, "Beige", "Comfortable and versatile cotton skirt.", "Cotton", null, null, "H&M Cotton Skirt", 39.99m, "S", 25 },
                    { 15, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7647), "c71c593b-289a-4197-9bcf-c3da824c980c", "Aldo", 11, "Nude", "Elegant leather heels perfect for formal events.", "Leather", null, null, "Aldo Leather Heels", 99.99m, "38", 20 },
                    { 16, new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7650), "c71c593b-289a-4197-9bcf-c3da824c980c", "Steve Madden", 11, "Red", "Bold red heels to complete any party look.", "Synthetic", null, null, "Steve Madden Red Heels", 110.00m, "37", 15 }
                });
        }
    }
}
