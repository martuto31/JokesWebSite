namespace AspNetCoreTemplate.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DateTimeinVicoveandshortnamedeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Vicoves");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Vicoves",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Vicoves");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Vicoves",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
