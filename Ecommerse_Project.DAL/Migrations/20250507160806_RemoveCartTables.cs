using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCartTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5af94c3a-351b-4d4e-b751-faf9c535bac1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCart_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CustomerCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_CustomerCart_CustomerCartId",
                        column: x => x.CustomerCartId,
                        principalTable: "CustomerCart",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c71c593b-289a-4197-9bcf-c3da824c980c", 0, "439935a7-f4d1-4b9a-b6ee-55b2247113ee", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEOBZdMhY+A+aw2v9qywy5SXxLxz4uqCeIU1h8EQ5v5JuZ5S4cOkpdQnzoJgtZ5FB4Q==", null, false, 0, "9c9734eb-bf40-42a0-83bd-b603e0e60cc9", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7404), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7463), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7467), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7471), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7474), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7478), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7480), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7483), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7486), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7490), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7494), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7497), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7640), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7644), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7647), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AddedAt", "AdminId", "ModifiedAt", "ModifiedBy" },
                values: new object[] { new DateTime(2025, 5, 7, 19, 8, 6, 407, DateTimeKind.Local).AddTicks(7650), "c71c593b-289a-4197-9bcf-c3da824c980c", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CustomerCartId",
                table: "CartItem",
                column: "CustomerCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCart_CustomerId",
                table: "CustomerCart",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "CustomerCart");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c71c593b-289a-4197-9bcf-c3da824c980c");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5af94c3a-351b-4d4e-b751-faf9c535bac1", 0, "db1aee00-bf5f-42de-b489-4425d49a16e8", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAENvThIkEjuqQrmfR94dntYlpbazGff59RmforO4piDe2lnM6Z81exgKu/QS0docypA==", null, false, 0, "d938599f-f5b1-4a91-af84-281054911ba5", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6126), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6185), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6193), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6198), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6202), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6208), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6213), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6217), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6222), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6227), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6232), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6236), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6240), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6244), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6248), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 1, 17, 53, 313, DateTimeKind.Local).AddTicks(6253), "5af94c3a-351b-4d4e-b751-faf9c535bac1" });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");
        }
    }
}
