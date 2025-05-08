using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addOrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_AspNetUsers_ApplicationUserId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TrackingDetails_TrackingDetailsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Paymens_Orders_OrderId",
                table: "Paymens");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "CustomerCart");

            migrationBuilder.DropIndex(
                name: "IX_Paymens_OrderId",
                table: "Paymens");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TrackingDetailsId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbe5a51d-4f62-4bca-b3f8-2677ebf030d1");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Paymens");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresss");

            migrationBuilder.RenameColumn(
                name: "TrackingDetailsId",
                table: "Orders",
                newName: "DeliveryMethodId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TrackingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BuyerEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Addresss",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Governorate",
                table: "Addresss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductMainImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b6a7769-d0b6-4c0b-b389-57d36cd2997d", 0, "0310c6dc-1f60-4819-b3cf-a7a772a3b1c3", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEJ8edfED7Sq/QDzifHcYfhFYYCVsHZLRkUit6txFcrYkJFGs2AQW76J/sdIjEiYmHg==", null, false, 0, "1c9a8a1f-f47c-46a7-acc2-41c1f3f74fb2", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_OrderId",
                table: "ShippingAddresses",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_AspNetUsers_ApplicationUserId",
                table: "Addresss",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_AspNetUsers_ApplicationUserId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b6a7769-d0b6-4c0b-b389-57d36cd2997d");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "TrackingDetails");

            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Governorate",
                table: "Addresss");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DeliveryMethodId",
                table: "Orders",
                newName: "TrackingDetailsId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Paymens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Addresss",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresss",
                type: "nvarchar(100)",
                maxLength: 100,
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
                    CustomerCartId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { "fbe5a51d-4f62-4bca-b3f8-2677ebf030d1", 0, "6c244a46-f3dc-44cb-be18-47df80a006dc", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEC9l++zzOYNQyZoI6rs+H1wEIhzIsEoeBS5yvorIJVEQatHJSHkJ8mrb0+UtstLfCQ==", null, false, 0, "18ec94cb-dbdb-4038-888b-4585daff1710", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Paymens_OrderId",
                table: "Paymens",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TrackingDetailsId",
                table: "Orders",
                column: "TrackingDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CustomerCartId",
                table: "CartItem",
                column: "CustomerCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCart_CustomerId",
                table: "CustomerCart",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_AspNetUsers_ApplicationUserId",
                table: "Addresss",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TrackingDetails_TrackingDetailsId",
                table: "Orders",
                column: "TrackingDetailsId",
                principalTable: "TrackingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paymens_Orders_OrderId",
                table: "Paymens",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
