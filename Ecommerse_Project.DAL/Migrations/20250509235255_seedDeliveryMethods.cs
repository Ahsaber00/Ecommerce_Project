using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedDeliveryMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbb033c6-44bb-4f8b-a34b-3a1a8a842a30");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d679a88-4f0e-4d25-929c-6a0e186621a9", 0, "e1cbe913-b61d-45e2-822b-0c82372b0eb3", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAENzqC4jtmDFXwWVR7N/0v7bkM+5i+al0zeersv2Ll9iRXP75G/oUYQK4Bzrl2aTxJg==", null, false, 0, "b6871a98-e89b-411e-9ac9-f882542fc94b", false, "Admin" });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "DeliveryTime", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "3-5 days", "Standard delivery within 3 to 5 business days", "Standard Delivery", 20m },
                    { 2, "1-2 days", "Fast delivery within 1 to 2 business days", "Express Delivery", 50m },
                    { 3, "Next day", "Delivery by the next business day", "Overnight Delivery", 80m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d679a88-4f0e-4d25-929c-6a0e186621a9");

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbb033c6-44bb-4f8b-a34b-3a1a8a842a30", 0, "fbfcbfc3-daf9-4c50-bebb-2d8cb15a1ddf", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEEo4vbG7fUyhL94hrFis3UU1Q/WuELWkSqbXNcXGNzUE14Z7UOOQZ9yuqToIXGFiqA==", null, false, 0, "35eae7ee-cfa8-41b2-bcba-138a03c077fe", false, "Admin" });
        }
    }
}
