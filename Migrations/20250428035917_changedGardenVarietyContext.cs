using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenVariety.Migrations
{
    /// <inheritdoc />
    public partial class changedGardenVarietyContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Gardens",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Gardens",
                keyColumn: "GardenId",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.InsertData(
                table: "Harvests",
                columns: new[] { "Id", "Date", "GardenId" },
                values: new object[] { 2, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Harvests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Gardens",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Gardens",
                keyColumn: "GardenId",
                keyValue: 1,
                column: "Type",
                value: 0);
        }
    }
}
