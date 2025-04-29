using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenVariety.Migrations
{
    /// <inheritdoc />
    public partial class changedGardens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Harvests",
                columns: new[] { "Id", "Date", "GardenId" },
                values: new object[] { 1, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Harvests",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
