using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryMethodsSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b6a7769-d0b6-4c0b-b389-57d36cd2997d");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbb033c6-44bb-4f8b-a34b-3a1a8a842a30", 0, "fbfcbfc3-daf9-4c50-bebb-2d8cb15a1ddf", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEEo4vbG7fUyhL94hrFis3UU1Q/WuELWkSqbXNcXGNzUE14Z7UOOQZ9yuqToIXGFiqA==", null, false, 0, "35eae7ee-cfa8-41b2-bcba-138a03c077fe", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbb033c6-44bb-4f8b-a34b-3a1a8a842a30");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b6a7769-d0b6-4c0b-b389-57d36cd2997d", 0, "0310c6dc-1f60-4819-b3cf-a7a772a3b1c3", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEJ8edfED7Sq/QDzifHcYfhFYYCVsHZLRkUit6txFcrYkJFGs2AQW76J/sdIjEiYmHg==", null, false, 0, "1c9a8a1f-f47c-46a7-acc2-41c1f3f74fb2", false, "Admin" });
        }
    }
}
