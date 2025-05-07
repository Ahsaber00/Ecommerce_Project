using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5af94c3a-351b-4d4e-b751-faf9c535bac1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "000e0936-dce3-458d-989e-357b76d854fb", 0, "8d61cec3-25e8-471d-905d-1b1689246b4a", "Admin", "Admin@mail.com", false, null, null, false, null, null, null, "AQAAAAIAAYagAAAAEIhMlJAmMee5butN+aHe3qn4aA54r96uZ8t59u4bDGjkJhdk+wqiPQCjq8PNbBvPZQ==", null, false, 0, "9c7b821d-60eb-421b-a5d3-1ba22c2f4164", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2844), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2905), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2909), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2912), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2917), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2921), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2924), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2927), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2930), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2934), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2937), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2940), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2943), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2947), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2950), "000e0936-dce3-458d-989e-357b76d854fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AddedAt", "AdminId" },
                values: new object[] { new DateTime(2025, 5, 6, 18, 26, 57, 178, DateTimeKind.Local).AddTicks(2952), "000e0936-dce3-458d-989e-357b76d854fb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000e0936-dce3-458d-989e-357b76d854fb");

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
        }
    }
}
