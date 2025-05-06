using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Customers_CustomerId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Admins_AdminID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Customers_CustomerId",
                table: "Wishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_Products_ProductId",
                table: "WishListProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_Wishlist_WishlistId",
                table: "WishListProducts");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CustomerProductReviews");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_CustomerId",
                table: "Addresss");

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Addresss");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Products",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AdminID",
                table: "Products",
                newName: "IX_Products_AdminId");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Wishlist",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Cart",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Addresss",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Addresss",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ca155cd-b1e8-4b1f-97ae-8be2ec854ded", 0, "4ae86b73-a5c0-44db-811d-ca962db4d550", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEDPhZK88KpKPBNG4WX9gx5YrzGlH9ULRYkYygqixfYzLRpoG3Pa5hNbzrSY36dA2PA==", null, false, 0, "ed65ecb5-958c-4aff-9ad6-de9be1855de7", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_ApplicationUserId",
                table: "Addresss",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_AspNetUsers_ApplicationUserId",
                table: "Addresss",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_AdminId",
                table: "Products",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_AspNetUsers_CustomerId",
                table: "Wishlist",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_Products_ProductId",
                table: "WishListProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_Wishlist_WishlistId",
                table: "WishListProducts",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_AspNetUsers_ApplicationUserId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_CustomerId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_AdminId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_AspNetUsers_CustomerId",
                table: "Wishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_Products_ProductId",
                table: "WishListProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_Wishlist_WishlistId",
                table: "WishListProducts");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_ApplicationUserId",
                table: "Addresss");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ca155cd-b1e8-4b1f-97ae-8be2ec854ded");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Addresss");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Products",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                newName: "IX_Products_AdminID");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Wishlist",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "AdminID",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Cart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Addresss",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Addresss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProductReviews",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductReviews", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerProductReviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "admin@example.com", "Admin User", "hashedpassword" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Men", null },
                    { 2, "Women", null },
                    { 4, "T-Shirts", 1 },
                    { 5, "Shirts", 1 },
                    { 6, "Jeans", 1 },
                    { 7, "Shoes", 1 },
                    { 8, "Dresses", 2 },
                    { 9, "Blouses", 2 },
                    { 10, "Skirts", 2 },
                    { 11, "Heels", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedAt", "AdminID", "Brand", "CategoryId", "Color", "Description", "Material", "Name", "Price", "Size", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6432), 1, "Nike", 4, "Black", "Comfortable and breathable cotton T-shirt, ideal for daily wear.", "Cotton", "Nike Cotton T-Shirt", 29.99m, "M", 50 },
                    { 2, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6497), 1, "Adidas", 4, "White", "Lightweight performance T-shirt made from premium polyester.", "Polyester", "Adidas Polyester T-Shirt", 34.99m, "L", 40 },
                    { 3, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6500), 1, "Ralph Lauren", 5, "Light Blue", "Elegant cotton shirt suitable for formal occasions.", "Cotton", "Ralph Lauren Cotton Shirt", 79.99m, "L", 30 },
                    { 4, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6503), 1, "Tommy Hilfiger", 5, "White", "Stylish and breathable linen shirt for summer days.", "Linen", "Tommy Hilfiger Linen Shirt", 85.50m, "M", 20 },
                    { 5, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6506), 1, "Levi's", 6, "Dark Blue", "Classic fit jeans crafted from durable denim material.", "Denim", "Levi's Denim Jeans", 69.99m, "32", 60 },
                    { 6, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6511), 1, "Diesel", 6, "Black", "Trendy slim-fit jeans with a modern look.", "Denim", "Diesel Slim Fit Jeans", 99.99m, "34", 25 },
                    { 7, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6514), 1, "Nike", 7, "White", "Lightweight running shoes with maximum cushioning.", "Synthetic", "Nike Running Shoes", 120.00m, "43", 35 },
                    { 8, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6516), 1, "Timberland", 7, "Brown", "Durable leather boots designed for rough terrains.", "Leather", "Timberland Leather Boots", 150.00m, "44", 20 },
                    { 9, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6519), 1, "Zara", 8, "Red", "Light cotton dress perfect for summer outings.", "Cotton", "Zara Summer Dress", 59.99m, "M", 40 },
                    { 10, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6566), 1, "H&M", 8, "Black", "Elegant silk evening dress for special occasions.", "Silk", "H&M Silk Evening Dress", 120.00m, "S", 15 },
                    { 11, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6569), 1, "Mango", 9, "Pink", "Stylish chiffon blouse suitable for office and casual wear.", "Chiffon", "Mango Chiffon Blouse", 45.00m, "S", 50 },
                    { 12, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6572), 1, "Forever 21", 9, "White", "Casual cotton blouse for everyday style.", "Cotton", "Forever 21 Cotton Blouse", 35.00m, "M", 45 },
                    { 13, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6575), 1, "Zara", 10, "Black", "Trendy high waist skirt for a modern chic look.", "Polyester", "Zara High Waist Skirt", 49.99m, "M", 30 },
                    { 14, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6577), 1, "H&M", 10, "Beige", "Comfortable and versatile cotton skirt.", "Cotton", "H&M Cotton Skirt", 39.99m, "S", 25 },
                    { 15, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6580), 1, "Aldo", 11, "Nude", "Elegant leather heels perfect for formal events.", "Leather", "Aldo Leather Heels", 99.99m, "38", 20 },
                    { 16, new DateTime(2025, 5, 5, 23, 54, 23, 580, DateTimeKind.Local).AddTicks(6583), 1, "Steve Madden", 11, "Red", "Bold red heels to complete any party look.", "Synthetic", "Steve Madden Red Heels", 110.00m, "37", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_CustomerId",
                table: "Addresss",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProductReviews_CustomerId",
                table: "CustomerProductReviews",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Customers_CustomerId",
                table: "Addresss",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Admins_AdminID",
                table: "Products",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Customers_CustomerId",
                table: "Wishlist",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_Products_ProductId",
                table: "WishListProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_Wishlist_WishlistId",
                table: "WishListProducts",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
