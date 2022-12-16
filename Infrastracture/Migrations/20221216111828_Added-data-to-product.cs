using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Addeddatatoproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreationDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "چادر مسافرتی", 2500000L },
                    { 2, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "اتو ", 3500000L },
                    { 3, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " پتو", 50000L },
                    { 4, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " تلویزیون", 650000L },
                    { 5, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " مبل", 45550000L }
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
        }
    }
}
