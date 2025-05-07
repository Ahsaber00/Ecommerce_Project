using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerse_Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Images",
                newName: "Url");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1105));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "AddedAt",
                value: new DateTime(2025, 4, 27, 17, 48, 6, 192, DateTimeKind.Local).AddTicks(1120));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "ImageFileName");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "AddedAt",
                value: new DateTime(2025, 4, 26, 12, 54, 42, 912, DateTimeKind.Local).AddTicks(377));
        }
    }
}
