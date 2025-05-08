using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initForTheHostedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12ef705b-af21-4b03-ada7-a14fb66965a1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fbe5a51d-4f62-4bca-b3f8-2677ebf030d1", 0, "6c244a46-f3dc-44cb-be18-47df80a006dc", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEC9l++zzOYNQyZoI6rs+H1wEIhzIsEoeBS5yvorIJVEQatHJSHkJ8mrb0+UtstLfCQ==", null, false, 0, "18ec94cb-dbdb-4038-888b-4585daff1710", false, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fbe5a51d-4f62-4bca-b3f8-2677ebf030d1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12ef705b-af21-4b03-ada7-a14fb66965a1", 0, "1ee9f878-b60c-4898-8281-a938612c13d3", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEMtyRGbtIIUbnVhI+ju8MdWA9LPTN+mdAtDTpXjZQ01aCHZGl4/2uR4Wr/zxI/wl0w==", null, false, 0, "eb6df624-24fb-41bc-a998-5d23d3eb0d3f", false, "Admin" });
        }
    }
}
