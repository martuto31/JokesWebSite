namespace AspNetCoreTemplate.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class LikedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LikedIdentyties",
                table: "Vicoves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikedIdentyties",
                table: "Vicoves");
        }
    }
}
